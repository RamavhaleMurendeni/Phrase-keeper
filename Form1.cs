using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phrase_keeper
{
    public partial class Form1 : Form
    {
        private List<string> wordsList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            string word = InputTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(word))
            {
                wordsList.Add(word);
                UpdateListBox();
            }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            string selectedWord = GetSelectedWord();
            if (selectedWord != null)
            {
                string newWord = InputTextBox.Text.Trim();
                if (!string.IsNullOrEmpty(newWord))
                {
                    int index = wordsList.IndexOf(selectedWord);
                    wordsList[index] = newWord;
                    UpdateListBox();
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            string selectedWord = GetSelectedWord();
            if (selectedWord != null)
            {
                wordsList.Remove(selectedWord);
                UpdateListBox();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            wordsList.Clear();
            UpdateListBox();
        }

        private string GetSelectedWord()
        {
            if (WordsListBox.SelectedIndex != -1)
            {
                return WordsListBox.SelectedItem.ToString();
            }
            return null;
        }

        private void UpdateListBox()
        {
            WordsListBox.DataSource = null;
            WordsListBox.DataSource = wordsList;
        }
    }
}
