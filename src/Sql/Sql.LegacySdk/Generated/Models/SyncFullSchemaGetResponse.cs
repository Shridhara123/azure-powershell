// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;

namespace Microsoft.Azure.Management.Sql.LegacySdk.Models
{
    /// <summary>
    /// Response for getting the full sync schema of a member or hub database.
    /// </summary>
    public partial class SyncFullSchemaGetResponse : AzureOperationResponse, IEnumerable<SyncFullSchema>
    {
        private IList<SyncFullSchema> _fullSchema;
        
        /// <summary>
        /// Optional. List of the full schema of member database.
        /// </summary>
        public IList<SyncFullSchema> FullSchema
        {
            get { return this._fullSchema; }
            set { this._fullSchema = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the SyncFullSchemaGetResponse class.
        /// </summary>
        public SyncFullSchemaGetResponse()
        {
            this.FullSchema = new LazyList<SyncFullSchema>();
        }
        
        /// <summary>
        /// Gets the sequence of FullSchema.
        /// </summary>
        public IEnumerator<SyncFullSchema> GetEnumerator()
        {
            return this.FullSchema.GetEnumerator();
        }
        
        /// <summary>
        /// Gets the sequence of FullSchema.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
