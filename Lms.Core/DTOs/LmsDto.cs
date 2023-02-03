using Lms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.DTOs
{
    public class LmsDto
    {
        public string Title { get; set; }

        public DateTime StartDate { get; set; }
        public string GamesTitle { get; set; }

        public DateTime Time { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
