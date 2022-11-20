using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Data;
using cms.Modulos.Util;
using System.Data;

namespace cms.Modulos.Usuario.Cn
{

    public class cnUsuario
    {
        
        private cmsEntities dbEntities = new cmsEntities();

        public cnUsuario()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public usuario GetUsuarioByID(long id_usuario)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.usuario);
            usuario result = (from u in dbEntities.usuario
                              where u.excluido == false && u.id_usuario == id_usuario
                              select u).SingleOrDefault();

            return result;
        }

        public usuario GetUsuarioByLogin(string usuario, string senha)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.usuario);
            usuario result = (from u in dbEntities.usuario
                              where u.excluido == false && u.usuario1 == usuario && u.senha == senha
                              select u).SingleOrDefault();
            return result;
        }

        public IQueryable<usuario> UsuarioProcurar(long? id_usuario, string nome, string usuario)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.usuario);
            IQueryable<usuario> result = (from u in dbEntities.usuario
                                          where u.excluido == false
                                          select u);

            if (id_usuario != null)
                result = result.Where(e => e.id_usuario == id_usuario);

            if (!string.IsNullOrEmpty(nome))
                result = result.Where(e => e.nome.Contains(nome));

            if (!string.IsNullOrEmpty(usuario))
                result = result.Where(e => e.usuario1.Contains(usuario));
   
            return result;
        }

        public bool UsuarioIsExist(string usuario)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.cliente);
            IQueryable<usuario> result = (from u in dbEntities.usuario
                                          where u.excluido == false && u.usuario1 == usuario
                                          select u);
            
            if (result.Count() == 0)
                return false;

            return true;
        }

        public bool UsuarioCadastrar(ref usuario pUsuario)
        {
            try
            {
                pUsuario.id_usuario = cms.Modulos.Util.Util.sp_getcodigo(Referencia.usuario);
                dbEntities.AddTousuario(pUsuario);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool UsuarioEditar(ref usuario pUsuario)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("usuario", pUsuario);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, pUsuario);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public IQueryable<menu> GetMenus()
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.menu);
            return dbEntities.menu;
        }

        public menu GetMenuByID(long id_menu)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.menu);

            menu result = (from m in dbEntities.menu
                          where m.id_menu == id_menu
                          select m).SingleOrDefault();

            return result;
        }

        public menu_detalhe GetMenuDetalheByID(long id_menu_detalhe)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.menu);

            menu_detalhe result = (from m in dbEntities.menu_detalhe
                           where m.id_menu_detalhe == id_menu_detalhe
                           select m).SingleOrDefault();

            return result;
        }
        
        public void AddPermissaoMenu(usuario pUsuario, menu pMenu)
        {
            if (pMenu == null)
                return;

            pUsuario.menu.Add(pMenu);            
            dbEntities.SaveChanges();
        }

        public void RemPermissaoMenu(usuario pUsuario, menu pMenu)
        {
            if (pMenu == null)
                return;

            pUsuario.menu.Remove(pMenu);
            dbEntities.SaveChanges();
        }

        public void AddPermissaoMenuDetalhe(usuario pUsuario, menu_detalhe pDetalhe)
        {
            if (pDetalhe == null)
                return;

            pUsuario.menu_detalhe.Add(pDetalhe);
            dbEntities.SaveChanges();
        }

        public void RemPermissaoMenuDetalhe(usuario pUsuario, menu_detalhe pDetalhe)
        {
            if (pDetalhe == null)
                return;

            pUsuario.menu_detalhe.Remove(pDetalhe);
            dbEntities.SaveChanges();
        }

        public bool UsuarioPermissaoMenu(long id_usuario, long id_menu)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.usuario);
            usuario result = (from u in dbEntities.usuario
                              where u.excluido == false && u.id_usuario == id_usuario
                              select u).SingleOrDefault();

            var mnu = result.menu.Where(m => m.id_menu == id_menu);
 
            if (mnu.Count() > 0)
                return true;

            return false;
        }

        public bool UsuarioPermissaoMenu(long id_usuario, string menu_nome)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.usuario);
            usuario result = (from u in dbEntities.usuario
                              where u.excluido == false && u.id_usuario == id_usuario
                              select u).SingleOrDefault();

            var mnu = result.menu.Where(m => m.nome == menu_nome);

            if (mnu.Count() > 0)
                return true;

            return false;
        }

        public bool UsuarioPermissaoMenuDetalhe(long id_usuario, long id_menu_detalhe)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.usuario);
            usuario result = (from u in dbEntities.usuario
                              where u.excluido == false && u.id_usuario == id_usuario
                              select u).SingleOrDefault();

            var mnuDetalhe = result.menu_detalhe.Where(m => m.id_menu_detalhe == id_menu_detalhe);

            if (mnuDetalhe.Count() > 0)
                return true;

            return false;
        }

    }

}
