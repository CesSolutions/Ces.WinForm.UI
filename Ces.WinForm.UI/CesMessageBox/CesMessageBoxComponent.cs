﻿using System.ComponentModel;

namespace Ces.WinForm.UI.CesMessageBox
{
    public partial class CesMessageBoxComponent : Component
    {
        public CesMessageBoxComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        public string? Title { get; set; }
        public CesMessageBoxIconEnum Icon { get; set; }
        public CesMessageBoxButtonsEnum Buttons { get; set; }
        public bool TopMost { get; set; }
        public CesMessageBoxSizeEnum Size { get; set; }
        public CesMessageBoxButtonImageEnum ButtonImage { get; set; }
        public System.Windows.Forms.TextImageRelation TextImageRelation { get; set; }
        //public CesMessageBoxButtonCaption ButtonCaption { get; set; }

        public void Show(string message)
        {
            Ces.WinForm.UI.CesMessageBox.CesMessage.Show(message, new CesMessageBoxOptions
            {
                Title = this.Title,
                Icon = this.Icon,
                Buttons = this.Buttons,
                TopMost = this.TopMost,
                Size = this.Size,
                ButtonImage = this.ButtonImage,
                TextImageRelation = this.TextImageRelation,
                //ButtonCaption = new CesMessageBoxButtonCaption();
            });
        }
    }
}
