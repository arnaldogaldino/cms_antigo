using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using cms.Data;
using System.Data.Objects;

namespace cms.Modulos.Util
{
    public static class AuthEntity
    {
        
        public static usuario UsuarioOnLine;
        public static empresa EmpresaPadrao;

        public static void LogEntities_SavingChanges(object sender, EventArgs e)
        {
            cmsEntities dbEntities = new cmsEntities();

            string originalValue;
            string currentValue;
            bool propertyChanged = false;

            var stateManager = ((cmsEntities)sender).ObjectStateManager;
            var insertedEntities = stateManager.GetObjectStateEntries(EntityState.Added);

            //Audit Inserted Entities 
            foreach (ObjectStateEntry insertedEntryEntity in insertedEntities)
            {
                //This is for relationships that get modified  
                if (insertedEntryEntity.IsRelationship && insertedEntryEntity.EntitySet.Name != "auditoria_log")
                {
                    EntityKey entityKeyFrom = (EntityKey)insertedEntryEntity.CurrentValues[1];
                    EntityKey entityKeyTo = (EntityKey)insertedEntryEntity.CurrentValues[0];

                    //Log the change 
                    //Create a audit header record 
                    auditoria_log audit = new auditoria_log();
                    audit.id_auditoria_log = cms.Modulos.Util.Util.sp_getcodigo(Referencia.auditoria_log);
                    audit.acao = "Update Relationship";
                    audit.data_acao = cms.Modulos.Util.Util.sp_getdatetime();
                    audit.nome_tabela = entityKeyFrom.EntitySetName;
                    
                    if (entityKeyFrom.EntityKeyValues != null) 
                    { 
                        audit.id_record = long.Parse(entityKeyFrom.EntityKeyValues[0].Value.ToString()); 
                    }

                    if (UsuarioOnLine != null)
                    {
                        audit.id_usuario = UsuarioOnLine.id_usuario;
                        audit.usuario = UsuarioOnLine.usuario1;
                    }
                    else
                    {
                        audit.usuario = "Unknown";
                    }

                    //Create the Audit Detail Record 
                    audit.auditoria_log_detalhe = new System.Data.Objects.DataClasses.EntityCollection<auditoria_log_detalhe>();

                    //Log the change 
                    auditoria_log_detalhe auditDetail = new auditoria_log_detalhe();
                    auditDetail.id_auditoria_log_detalhe = cms.Modulos.Util.Util.sp_getcodigo(Referencia.auditoria_log_detalhe);
                    auditDetail.nome_coluna = entityKeyTo.EntityKeyValues[0].Key.ToString();
                    auditDetail.valor_original = "";
                    auditDetail.valor_corrente = entityKeyTo.EntityKeyValues[0].Value.ToString();
                    
                    audit.auditoria_log_detalhe.Add(auditDetail);
                    dbEntities.AddToauditoria_log(audit);
                }
                else //Not a relationship 
                {
                    //As long as the record being inserted isn't an auditlog then track changes 
                    if (insertedEntryEntity.EntitySet.Name != "auditoria_log")
                    {
                        //Log the change 
                        //Create a audit header record 
                        auditoria_log audit = new auditoria_log();
                        audit.id_auditoria_log = cms.Modulos.Util.Util.sp_getcodigo(Referencia.auditoria_log);
                        audit.acao = "New";
                        audit.data_acao = cms.Modulos.Util.Util.sp_getdatetime();
                        audit.nome_tabela = insertedEntryEntity.EntitySet.Name;

                        try
                        {
                            audit.id_record = long.Parse(insertedEntryEntity.CurrentValues[0].ToString());
                        }
                        catch { }

                        if (UsuarioOnLine != null)
                        {
                            audit.id_usuario = UsuarioOnLine.id_usuario;
                            audit.usuario = UsuarioOnLine.usuario1;
                        }
                        else
                        {
                            audit.usuario = "Unknown";
                        }

                        audit.auditoria_log_detalhe = new System.Data.Objects.DataClasses.EntityCollection<auditoria_log_detalhe>();

                        //Go through all of the modified properties and add an audit detail record 
                        foreach (System.Data.Common.FieldMetadata fm in insertedEntryEntity.CurrentValues.DataRecordInfo.FieldMetadata)
                        {
                            var columnName = fm.FieldType.Name.ToString();
                            currentValue = insertedEntryEntity.CurrentValues[fm.Ordinal].ToString();
                            
                            if (currentValue.Trim() != "")
                            {
                                //Log the change 
                                auditoria_log_detalhe auditDetail = new auditoria_log_detalhe();
                                auditDetail.id_auditoria_log_detalhe = cms.Modulos.Util.Util.sp_getcodigo(Referencia.auditoria_log_detalhe);
                                auditDetail.nome_coluna = columnName;
                                auditDetail.valor_original = "";
                                auditDetail.valor_corrente = currentValue;

                                audit.auditoria_log_detalhe.Add(auditDetail);
                            }
                        }

                        dbEntities.AddToauditoria_log(audit);
                    }
                }
            }

            var modifiedEntities = stateManager.GetObjectStateEntries(EntityState.Modified);

            //Audit Modified Entities 
            foreach (ObjectStateEntry modifiedEntryEntity in modifiedEntities)
            {

                //Check if any properties changed 
                foreach (string modifiedProperty in modifiedEntryEntity.GetModifiedProperties())
                {
                    originalValue = modifiedEntryEntity.OriginalValues[modifiedProperty].ToString();
                    currentValue = modifiedEntryEntity.CurrentValues[modifiedProperty].ToString();

                    if (originalValue.Trim() == currentValue.Trim())
                    {
                        continue;
                    }

                    propertyChanged = true;
                }

                //Only if a property has changed do we audit the change 
                if (propertyChanged)
                {
                    //Log the change 
                    //Create a audit header record 
                    auditoria_log audit = new auditoria_log();
                    
                    audit.id_auditoria_log = cms.Modulos.Util.Util.sp_getcodigo(Referencia.auditoria_log);
                    audit.acao = "Update";
                    audit.data_acao = cms.Modulos.Util.Util.sp_getdatetime();
                    audit.nome_tabela = modifiedEntryEntity.EntitySet.Name;

                    if (UsuarioOnLine != null)
                    {
                        audit.id_usuario = UsuarioOnLine.id_usuario;
                        audit.usuario = UsuarioOnLine.usuario1;
                    }
                    else
                    {
                        audit.usuario = "Unknown";
                    }
                    
                    audit.id_record = int.Parse(modifiedEntryEntity.EntityKey.EntityKeyValues[0].Value.ToString());
                    audit.auditoria_log_detalhe = new System.Data.Objects.DataClasses.EntityCollection<auditoria_log_detalhe>();

                    //Go through all of the modified properties and add an audit detail record 
                    foreach (string modifiedProperty in modifiedEntryEntity.GetModifiedProperties())
                    {
                        originalValue = modifiedEntryEntity.OriginalValues[modifiedProperty].ToString();
                        currentValue = modifiedEntryEntity.CurrentValues[modifiedProperty].ToString();

                        if (originalValue.Trim() != currentValue.Trim())
                        {
                            auditoria_log_detalhe auditDetail = new auditoria_log_detalhe();
                            auditDetail.id_auditoria_log_detalhe = cms.Modulos.Util.Util.sp_getcodigo(Referencia.auditoria_log_detalhe);
                            auditDetail.nome_coluna = modifiedProperty;
                            auditDetail.valor_original = originalValue;
                            auditDetail.valor_corrente = currentValue;
                            audit.auditoria_log_detalhe.Add(auditDetail);
                        }
                    }

                    dbEntities.AddToauditoria_log(audit);
                }
            }

            var deletedEntities = stateManager.GetObjectStateEntries(EntityState.Deleted);

            //Audit Deleted Entities 
            foreach (ObjectStateEntry deletedEntryEntity in deletedEntities)
            {
                //This is for relationships that get modified 
                if (deletedEntryEntity.IsRelationship)
                {
                    //Not sure what to do here 
                }
            }

            dbEntities.SaveChanges();
        }

        public static void SetUsuario(usuario pUsuario)
        {
            UsuarioOnLine = pUsuario;
        }

        public static void SetEmpresa(empresa pEmpresa)
        {
            EmpresaPadrao = pEmpresa;
        }

        public static void UsuarioOnlineClear()
        {
            UsuarioOnLine = null;
        }

        public static long CadastrarMenu(long? id_menu_pai, string nome, string texto, string descricao)
        {
            cmsEntities dbEntities = new cmsEntities();
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.menu);
            
            var mnu_exist = (from m in dbEntities.menu
                             where m.nome == nome
                             select m).SingleOrDefault();
            
            if (mnu_exist != null)
                return mnu_exist.id_menu;

            menu mnu = new menu();

            mnu.id_menu = cms.Modulos.Util.Util.sp_getcodigo(Referencia.menu);
            mnu.id_menu_pai = id_menu_pai;
            mnu.nome = nome;
            mnu.texto = texto;
            mnu.descricao = descricao;

            dbEntities.AddTomenu(mnu);

            dbEntities.SaveChanges();
            return mnu.id_menu;
        }

    }
}