﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalaha
{
    class Field
    {
        public int Value { get; set; }
        public int Position;
        private FieldKind Kind;
        public Field Follower { get; set; }
        public System.Windows.Forms.Button Button;
        public bool IsLastField = false;

        public Field(int Value, int Position, FieldKind Kind, Player Player, System.Windows.Forms.Button Button)
        {
            this.Value = Value;
            this.Kind = Kind;
            this.Position = Position;
            this.Button = Button;
            this.Button.Text = Value.ToString();
        }

        public bool Fill (int Hand)
        {
            Value++;                                    //Stein wird aus der Hand...
            Hand--;                                     //...in das Feld gelegt
            Button.Text = Value.ToString();             //Die Anzeige wird aktualisiert
            if (Hand > 0)                               //Falls noch etwas in der Hand ist...
            {
                bool LetztesFeldistKalaha = Follower.Fill(Hand);
                if (LetztesFeldistKalaha == true)        //Durch Rekursion werden die Felder durchgegangen
                {
                    Console.WriteLine("Rückgegebener Wert ist true");
                    return true;
                }
                else
                {
                    Console.WriteLine("Rückgegebener Wert ist false");
                    return false;
                }
            } else if(this.Kind == FieldKind.Normal)
            {
                Console.WriteLine("Kalahaprüfung ist false");
                IsLastField = true;
                return false;
            } else 
            {
                Console.WriteLine("Kalahaprüfung ist true");
                return true;
            }
        }

        public int Empty()
        {
            int x = Value;
            Value = 0;
            Button.Text = Value.ToString();
            return x;
        }
    }
}