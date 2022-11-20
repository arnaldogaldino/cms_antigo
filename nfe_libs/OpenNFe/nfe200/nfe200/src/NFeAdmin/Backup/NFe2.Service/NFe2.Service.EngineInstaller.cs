using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace NFSe.Service
{
    [RunInstaller(true)]
    public partial class EngineNFSeInstaller : Installer
    {
        public EngineNFSeInstaller()
        {
            InitializeComponent();

            
        }
    }
}