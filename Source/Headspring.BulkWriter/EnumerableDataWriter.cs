﻿using System.Collections;
using System.Threading.Tasks;

namespace Headspring.BulkWriter
{
    public class EnumerableDataWriter
    {
        public void WriteToDatabase(IEnumerable items, IBulkCopyFactory bulkCopyFactory)
        {
            IEnumerator enumerator = items.GetEnumerator();
            if (enumerator.MoveNext())
            {
                IPropertyToOrdinalMappings mappings;
                using (IBulkCopy bulkCopy = bulkCopyFactory.Create(enumerator.Current, out mappings))
                {
                    using (var dataReader = new EnumeratorDataReader(enumerator.Current, enumerator, mappings))
                    {
                        bulkCopy.WriteToServer(dataReader);
                    }
                }
            }
        }

        public async Task WriteToDatabaseAsync(IEnumerable items, IBulkCopyFactory bulkCopyFactory)
        {
            IEnumerator enumerator = items.GetEnumerator();
            if (enumerator.MoveNext())
            {
                IPropertyToOrdinalMappings mappings;
                using (IBulkCopy bulkCopy = bulkCopyFactory.Create(enumerator.Current, out mappings))
                {
                    using (var dataReader = new EnumeratorDataReader(enumerator.Current, enumerator, mappings))
                    {
                        await bulkCopy.WriteToServerAsync(dataReader);
                    }
                }
            }
        }
    }
}