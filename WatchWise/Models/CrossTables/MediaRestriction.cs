using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchWise.Models.CrossTables
{
	public class MediaRestriction
	{

        public int MediaId { get; set; }

        public byte RestrictionId { get; set; }

        [ForeignKey("MediaId")]
        public Media? Media { get; set; }

        [ForeignKey("RestrictionId")]
        public Restriction? Restriction { get; set; }

    }
}

