using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    [Serializable]
    public class Property
    {
        [Serializable]
        public enum PropertyType { OneRoomApartment, TwoRoomApartment, ThreeRoomApartment, CountryHouse }

        public Property(PropertyType type, int cost, int id)
        {
            this.type = type;
            this.cost = cost;
            this.id = id;
        }
        private PropertyType type;
        private int cost;
        private int id;
        [ExcludeFromCodeCoverage]
        public PropertyType Type
        {
            get { return this.type; }
        }
        public int Cost
        {
            get { return this.cost; }
        }
        public int ID
        {
            get { return this.id; }
        }
        [ExcludeFromCodeCoverage]
        public void SetType(PropertyType newType)
        {
            this.type = newType;
        }
        [ExcludeFromCodeCoverage]
        public void SetCost(int newCost)
        {
            this.cost = newCost;
        }
        [ExcludeFromCodeCoverage]
        public void SetID(int newID)
        {
            this.id = newID;
        }
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return
                "ID:   " + this.id + "\n" +
                "Тип:  " + this.type.ToString() + "\n" +
                "Цiна: " + this.cost;
        }
    }
}
