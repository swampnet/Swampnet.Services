using System;
using System.Collections.Generic;
using System.Text;

namespace Swampnet.Services.Images.Entities
{
    /*
     * Keep in mind that an image itself contains meta-data about itself, and we should be using *that* as the
     * canonical source for some of this stuff.
     * 
     * Store in ImageDetails if we need to represent it in the database
     */
    public class ImageDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
		public string ContentType { get; set; }
	}
}
