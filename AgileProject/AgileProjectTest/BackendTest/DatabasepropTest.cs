using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProjectTest.BackendTest
{
    public record Card
    {
        public Card(string front, string back)
        {
            Front = front;
            Back = back;
        }

        public string Front { get; set; }
        public string Back { get; set; }

        private bool Correct = false;

        /*
        //ID if needed
        public string ID { get; set; }
        //Name if needed
        public string Name { get; set; }
        */
    }

    public record Set
    {
        public string SetName { get; set; }
        public List<Card> Cards { get; set; }

        public Set()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            try
            {
                Cards.Add(card);
            }
            catch 
            {
                throw new Exception("Failed to add card");
            }
        }

        public void RemoveCard(Card card) 
        {
            try
            {
                Cards.Remove(card);
            }
            catch
            {
                throw new Exception("Failed to remove card");
            }
        }

        public Card GetCard(int x)
        {
            return Cards[x];
        }

        public int Size() 
        {
            return Cards.Count;
        }
    }

    public record Folder
    {
        public string FolderName { get; set; }
        public List<Set> Sets { get; set; }

        public Folder(string name)
        {
            FolderName = name;
            Sets = new List<Set>();
        }

        public void AddSet(Set s)
        {
            try
            {
                Sets.Add(s);
            }
            catch
            {
                throw new Exception("Failed to add Set");
            }
        }

        public void RemoveSetByPlace(int x)
        {
            Sets.RemoveAt(x);
        }

        public void RemoveSetByName(string name)
        {
            for(int i = 0; i < Sets.Count; i++)
            {
                if(Sets[i].SetName == name)
                {
                    Sets.RemoveAt(i);
                }
            }
        }

        public int Size()
        {
            return Sets.Count;
        }
    }
}
