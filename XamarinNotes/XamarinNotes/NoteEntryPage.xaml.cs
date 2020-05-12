using System;
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
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();


            noteTextEditor.Text = FileManager.LoadText();
        }

        async private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            FileManager.SaveText(note.ToString(), note.FileName);
            await Navigation.PopAsync();
        }

        async private void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            FileManager.DeleteFile(note.FileName);
            note.Text = string.Empty;
            await Navigation.PopAsync();
        }
    }
}
