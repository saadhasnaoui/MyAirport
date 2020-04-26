using GraphQL.Types;
using PC.MyAirport.EF;
using MyAirportGraphQl.GraphQLType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirportGraphQl
{
    public class AirportQuery : ObjectGraphType
    {
        public AirportQuery(MyAirportContext db)
        {
            Field<ListGraphType<BagageType>>(
                "bagages",
                resolve: context => db.Bagages.ToList());
        }
            
            
    }
}
