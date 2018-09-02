﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management;


namespace Microsoft.WindowsAzure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Remove, AzureSubscriptionServicePrincipalNounName)]
    [OutputType(typeof(AzureOperationResponse))]
    public class RemoveAzureSubscriptionServicePrincipal : ServiceManagementBaseCmdlet
    {
        public RemoveAzureSubscriptionServicePrincipal()
            : base()
        {

        }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ServicePrincipal Object Id")]
        [ValidateNotNullOrEmpty]
        [Alias("ObjectId")]
        public string ServicePrincipalObjectId { get; set; }

        public override void ExecuteCmdlet()
        {
            var response = ManagementClient.SubscriptionServicePrincipals.Delete(ServicePrincipalObjectId);
            WriteObject(response);
        }
    }
}