﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinNotes
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            noteTextEditor.Text = FileManager.LoadText();
        }

        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            FileManager.SaveText(noteTextEditor.Text);
        }

        private void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            FileManager.DeleteFile();
            noteTextEditor.Text = string.Empty;
        }
    }
}
