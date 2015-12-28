﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;	

namespace goFish
{
	class Player
	{
		private string name;
		public string Name { get { return name; } }
		private Random random;
		private Deck cards;
		private TextBox textBoxOnForm;

		public Player(String name, Random random, TextBox textBoxOnForm) {
			
		}

		public IEnumerable<Values> PullOutBooks() {
			List<Values> books = new List<Values>();
			for(int i = 1; i<=13; i++) {
				Values value = (Values)i;
				int HowMany = 0;
				for(int card=0; card<cards.Count; card++) {
					if (cards.Peek(card).Value == value)
						HowMany++;
				}
				if (HowMany == 4) {
					books.Add(value);
					for (int card = cards.Count - 1; card >= 0; card--)
						cards.Deal(card);
				}
			}
			return books;
		}

		public Values GetRandomValue() {

		}

		public Deck DoYouHaveAny(Values value) {

		}

		public void AskForACard(List<Player> players, int myIndex, Deck stock) {

		}
		public void AskforACard(List<Player> players, int myIndex, Deck stock, Values value) {

		}

		public int CardCount { get { return cards.Count; } }
		public void TakeCard(Card card) { cards.Add(card); }
		public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
		public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
		public void SortHand() { cards.SortByValue(); }
	}
}