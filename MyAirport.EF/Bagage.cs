
using MyAirport.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC.MyAirport.EF
{
    /// <summary>
    /// Objet Bagage
    /// </summary>
    public class Bagage
    {
        /// <summary>
        /// Id clé primaire de l'objet bagage
        /// </summary>
        public int BagageId { get; set; }
        /// <summary>
        /// Vol associé au bagage
        /// </summary>
        public int? VolId { get; set; }
        /// <summary>
        /// CoddeIata du bagage, unique à un instant t
        /// </summary>
        public string CodeIata { get; set; }
        /// <summary>
        /// Date création bagage 
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Propriété de navigation
        /// </summary>
        public Vol? Vol { get; set; }

        /// <summary>
        /// Classe du passager 
        /// </summary>
        public string? Classe { get; set; }
        /// <summary>
        /// priorité du passager 
        /// </summary>
        public bool? Prioritaire { get; set; }
        /// <summary>
        /// Statut du bagage
        /// </summary>
        public string? Sta { get; set; }
        /// <summary>
        /// ?
        /// </summary>
        public string? Ssur { get; set; }
        /// <summary>
        /// Lieu de destination du vol
        /// </summary>
        public string? Destination { get; set; }
        /// <summary>
        /// Lieu de l'escale
        /// </summary>
        public string? Escale { get; set; }

        /// <summary>
        /// Création d'un bagage vide 
        /// </summary>
        public Bagage() { }

        /// <summary>
        /// Création d'un bagage
        /// </summary>
        public Bagage(string codeIata, DateTime dateCreation)
        {
            CodeIata = codeIata;
            DateCreation = dateCreation;
        }

    }
}
