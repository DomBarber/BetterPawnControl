﻿using Verse;

namespace BetterPawnControl
{
    public class Policy : IExposable
    {
        internal int id = 0;
        public string label = "BPC.Auto".Translate();

        public Policy() { }

        public Policy(int id, string label)
        {
            this.id = id;
            this.label = label;
        }

        public override string ToString()
        {
            return "Id:" + id + "  Label: " + label;
        }

        public virtual bool Equals(Policy other)
        {
            return this.id == other.id && this.label == other.label;
        }

        /// <summary>
        /// Data for saving/loading
        /// </summary>
        public void ExposeData()
        {
            Scribe_Values.Look<string>(ref label, "label", "Auto", true);
            Scribe_Values.Look<int>(ref id, "id", 0, true);
        }
    }
}