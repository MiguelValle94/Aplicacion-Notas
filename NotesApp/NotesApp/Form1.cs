using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class Form1 : Form
    {
        List<Note> _notes = new List<Note>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text) && 
                !string.IsNullOrEmpty(txtNotes.Text))
            {
                var note = new Note();
                note.Title = txtTitle.Text;
                note.Notes = txtNotes.Text;
                _notes.Add(note);

                PopulateNotes();
                ClearForm();
            }
        }

        private void PopulateNotes()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _notes;
            grdNotes.DataSource = bs;
        }

        private void ClearForm()
        {
            txtTitle.Text = "";
            txtNotes.Text = "";
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (grdNotes.SelectedRows != null)
            {
                if (grdNotes.SelectedCells.Count > 1)
                {
                    string title = grdNotes.SelectedCells[0].Value.ToString();
                    string notes = grdNotes.SelectedCells[1].Value.ToString();

                    txtTitle.Text = title;
                    txtNotes.Text = notes;
                } else
                {
                    string title = grdNotes.SelectedCells[0].Value.ToString();
                    string notes = "";
                    foreach (Note item in _notes)
                    {
                        if (item.Title == grdNotes.SelectedCells[0].Value.ToString())
                        {
                            notes = item.Notes;
                        }
                    }

                    txtTitle.Text = title;
                    txtNotes.Text = notes;
                }
               

            }
        }
    }
}
