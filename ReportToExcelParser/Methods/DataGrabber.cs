using System;
using System.Collections.Generic;
using System.Linq;
using ReportToExcelParser.Models;

namespace ReportToExcelParser.Methods
{
    public class DataGrabber
    {
        public class Unite
        {
            private string _name;
            private string _value;
            private string _units;
            private string _unitsType;
            private Limits _limit;
            public Unite(string name, string value, string units,string unitsType, Limits limits)
            {
                _name = name;
                _value = value;
                _units = units;
                _unitsType = unitsType;
                _limit = limits;
            }
            public string Name 
            { 
                get 
                { 
                    return _name; 
                }
              set 
                { 
                    _name = value; 
                }
            }
            public string Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                }
            }
            public string Units
            {
                get
                {
                    return _units;
                }
                set
                {
                    _units = value;
                }
            }
            public string UnitsType
            {
                get
                {
                    return _unitsType;
                }
                set
                {
                    _unitsType = value;
                }
            }
            public Limits Limit
            {
                get
                {
                    return _limit;
                }
                set
                {
                    _limit = value;
                }
            }

        }
        public class Limits
        {
            private string _limitLow;
            private string _limitHigh;

            public Limits(string low, string high)
            {
                _limitLow = low;
                _limitHigh = high;
            }

            public string LimitLow
            {
                get
                {
                    return _limitLow;
                }
                set
                {
                    _limitLow = value;
                }
            }
            public string LimitHigh
            {
                get
                {
                    return _limitHigh;
                }
                set
                {
                    _limitHigh = value;
                }
            }
        }
        public static Unite GetResult(Prop prop)
        {
            string name = GetName(prop.prop.Where(x => x.Name == "TS").FirstOrDefault());
            string value = GetValue(prop.prop.Where(x => x.Name == "Numeric").FirstOrDefault());
            string units = GetValue(prop.prop.Where(x => x.Name == "Units").FirstOrDefault());
            string unitsType = GetUnitType(prop.prop.Where(x => x.Name == "Numeric").FirstOrDefault());
            Limits limits = GetLimits(prop.prop.Where(x => x.Name == "Limits").FirstOrDefault());

            return new Unite(name, value, units, unitsType, limits);
        }
        private static string GetName(Prop prop)
        {
            if (prop == null)
                return null;
            return GetValue(prop.prop.Where(x => x.Name == "StepName").FirstOrDefault());
        }
        private static Limits GetLimits(Prop prop)
        {
            if (prop == null || prop.prop == null)
                return null;
            
            string LimitLow = GetValue(prop.prop.Where(x => x.Name == "Low").FirstOrDefault());
            string LimitHigh = GetValue(prop.prop.Where(x => x.Name == "High").FirstOrDefault());

            return new Limits(LimitLow,LimitHigh);
        }
        private static string GetValue(Prop prop)
        {
            if (prop != null && prop.Value.Count > 0)
                return prop.Value[0].Text;
            return null;
        }
        private static string GetUnitType(Prop prop)
        {
            if (prop != null && prop.Type != null)
                return prop.Type;
            return null;
        }

        private static string GetAdditionalResult(Prop prop)
        {
            if (prop == null || prop.Value == null)
                return null;
            var step1 = prop.Value.FirstOrDefault();
            var step2 = step1.prop.Value.FirstOrDefault().Text;

            return step2;
        }
    }
}

