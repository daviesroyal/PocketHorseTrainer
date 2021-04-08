using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.Models.Horses
{
    public enum Face
    {
        None,
        Snip,
        IrregularStar,
        StarStrip,
        Star,
        FaintStar,
        BaldFace,
        InterruptedStripe,
        IrregularBlaze,
        StripeSnip,
        Stripe,
        Blaze
    }

    public enum Leg
    {
        HighWhite,
        Stocking,
        Boot,
        Sock,
        Pastern,
        Coronet
    }

    public class Markings
    {
        public int Id { get; set; }

        public Face FaceMarking { get; set; }
        public Leg FrontLeft { get; set; }
        public Leg FrontRight { get; set; }
        public Leg BackLeft { get; set; }
        public Leg BackRight { get; set; }

        public Markings()
        {
        }
    }
}
