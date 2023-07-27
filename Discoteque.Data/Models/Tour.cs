using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discoteque.Data.Models;

public class Tour : BaseEntity<int>
{
    /// <summary>
    /// The Name of the tour
    /// </summary>
    public string Name { get; set; } = "";
    
    /// <summary>
    /// The city the tour is on 
    /// </summary>
    public string City { get; set; } = "";

    /// <summary>
    /// The gig's date
    /// </summary>
    public DateTime Date { get; set; }= new DateTime(1900,01,01);

    /// <summary>
    /// Ticket sale's status 
    /// </summary>
    public bool IsItSoldOut { get; set; }= false;
    
    /// <sumary>
    /// Name of the album to witch the song belongs 
    /// </sumary>

    [ForeignKey("Id")]
    public int ArtistId { get; set; }

    public virtual Artist? Artist { get; set; }
}