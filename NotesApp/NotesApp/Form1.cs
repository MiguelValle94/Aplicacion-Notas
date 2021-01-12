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
                string title = grdNotes.SelectedCells[0].Value.ToString();
                string notes = LookForNote(title);

                txtTitle.Text = title;
                txtNotes.Text = notes;
            }
        }

        private string LookForNote(string title)
        {
            foreach (Note item in _notes)
            {
                if (item.Title == title)
                {
                    return item.Notes;
                }
            }
            return "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdNotes.SelectedRows != null)
            {
                string title = grdNotes.SelectedCells[0].Value.ToString();
                DeleteNote(title);

                ClearForm();
                PopulateNotes();
            }
        }

        private void DeleteNote(string title)
        {
            Note noteToRemove = null;
            foreach (Note item in _notes)
            {
                if (item.Title == title)
                {
                    noteToRemove = item;
                }
            }

            if (noteToRemove != null)
            {
                _notes.Remove(noteToRemove);
            }
        }
    }
}
