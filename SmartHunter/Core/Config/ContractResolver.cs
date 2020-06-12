using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SmartHunter.Core.Config
{
    public class ContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            // Replace dictionaries entirely unless integrity is preserved
            var property = base.CreateProperty(member, memberSerialization);
            if (property.ObjectCreationHandling == null && GetDictionaryKeyType(property.PropertyType) != null && member.GetCustomAttribute<PreserveCollectionIntegrity>() == null)
            {
                property.ObjectCreationHandling = ObjectCreationHandling.Replace;
            }

            // Exclude empty arrays from writing
            if (property.PropertyType.IsArray)
            {
                property.ShouldSerialize = instance =>
                {
                    var arrayField = instance.GetType().GetField(property.PropertyName);
                    if (arrayField != null)
                    {
                        var array = arrayField.GetValue(instance) as Array;
                        if (array != null)
                        {
                            return array.Length > 0;
                        }
                    }

                    return true;
                };
            }

            return property;
        }

        Type GetDictionaryKeyType(Type type)
        {
            while (type != null)
            {
                if (type.IsGenericType)
                {
                    var genType = type.GetGenericTypeDefinition();
                    if (genType == typeof(Dictionary<,>))
                    {
                        return type.GetGenericArguments()[0];
                    }
                }

                type = type.BaseType;
            }

            return null;
        }
    }
}
