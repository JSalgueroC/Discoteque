using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discoteque.Data.Models;

public class Song : BaseEntity<int>
{
    /// <summary>
    /// The Name of the song
    /// </summary>
    public string Name { get; set; } = "";
    
    /// <summary>
    /// Song duration in seconds
    /// </summary>
    public int  Duration  { get; set; } = 0;

    /// <sumary>
    /// Name of the album to witch the song belongs 
    /// </sumary>

    [ForeignKey("Id")]
    public int AlbumId { get; set; }

    public virtual Album? Album { get; set; }
}