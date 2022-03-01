using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardDeck
{
    public partial class Form1 : Form
    {
        // deck of cards
        List<string> deck = new List<string>();
        List<string> dealerCards = new List<string>();
        List<string> playerCards = new List<string>();

        public Form1()
        {
            InitializeComponent();

            //fill deck with standard 52 cards
            //H - Hearts, D - Diamonds, C - Clubs, S - Spades

            deck.AddRange(new string[] { "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "10H", "JH", "QH", "KH", "AH" });
            deck.AddRange(new string[] { "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "10D", "JD", "QD", "KD", "AD" });
            deck.AddRange(new string[] { "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "10C", "JC", "QC", "KC", "AC" });
            deck.AddRange(new string[] { "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "JS", "QS", "KS", "AS" });

            ShowDeck();

            dealButton.Enabled = false;
            collectButton.Enabled = false;
          dealButton.BackColor = Color.White;
            collectButton.BackColor = Color.White;
         
        }

        public void ShowDeck()
        {
            outputLabel.Text = "";
            for (int i = 0; i < deck.Count; i++)
            {
                outputLabel.Text += $"{deck[i].ToString()} ";
            }
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
            List<string> deckTemp = new List<string>();
            Random randGen = new Random();

            while (deck.Count > 0)
            {
                int index = randGen.Next(0, deck.Count);
                deckTemp.Add(deck[index]);
                deck.RemoveAt(index);
            }

            deck = deckTemp;

            ShowDeck();
            dealButton.Enabled = true;
          shuffleButton.Enabled = false;
            if (dealButton.Enabled == true)
            {
                dealButton.BackColor = Color.GreenYellow;
            }
            if (shuffleButton.Enabled == false)
            {
                shuffleButton.BackColor = Color.White;
            }
        }


        private void dealButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                dealerCards.Add(deck[0]);
                deck.RemoveAt(0);
                playerCards.Add(deck[0]);
                deck.RemoveAt(0);
            }

            dealerCardsLabel.Text = "";
            playerCardsLabel.Text = "";

            for (int i = 0; i < dealerCards.Count; i++)
            {
                dealerCardsLabel.Text += $"{dealerCards[i].ToString()} ";
            }
            for (int i = 0; i < playerCards.Count; i++)
            {
                playerCardsLabel.Text += $"{playerCards[i].ToString()} ";
            }

            ShowDeck();
            collectButton.Enabled = true;
            dealButton.Enabled = false;
            if (dealButton.Enabled == false)
            {
                dealButton.BackColor = Color.White;
            }
            if (collectButton.Enabled == true)
            {
                collectButton.BackColor = Color.GreenYellow;
            }
        }

        private void collectButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                deck.Add(dealerCards[0]);
                dealerCards.RemoveAt(0);
                deck.Add(playerCards[0]);
                playerCards.RemoveAt(0);
            }

            dealerCardsLabel.Text = "";
            playerCardsLabel.Text = "";

            ShowDeck();

            collectButton.Enabled = false;
            shuffleButton.Enabled = true;
            if (collectButton.Enabled == false)
            {
                collectButton.BackColor = Color.White;
            }
            if (shuffleButton.Enabled == true)
            {
                shuffleButton.BackColor = Color.GreenYellow;
            }
        }

        private void dealerCardsLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
