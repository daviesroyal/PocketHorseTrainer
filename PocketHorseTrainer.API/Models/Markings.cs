using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Markings
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

        public enum FrontLeft
        {
            HighWhite,
            Stocking,
            Boot,
            Sock,
            Pastern,
            Coronet
        }

        public enum FrontRight
        {
            HighWhite,
            Stocking,
            Boot,
            Sock,
            Pastern,
            Coronet
        }

        public enum BackLeft
        {
            HighWhite,
            Stocking,
            Boot,
            Sock,
            Pastern,
            Coronet
        }

        public enum BackRight
        {
            HighWhite,
            Stocking,
            Boot,
            Sock,
            Pastern,
            Coronet
        }

        public Markings()
        {
        }
    }
}
