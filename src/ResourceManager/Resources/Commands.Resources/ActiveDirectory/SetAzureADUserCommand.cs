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

using Microsoft.Azure.Commands.Resources;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using System;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Updates an existing AD user.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmADUser", SupportsShouldProcess = true), OutputType(typeof(PSADUser))]
    public class SetAzureADUserCommand: ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The userPrincipalName or ObjectId of the user to be updated.")]
        [ValidateNotNullOrEmpty]
        public string UPNOrObjectId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "New display name for the user.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }
        
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "true for enabling the account; otherwise, false.")]
        [ValidateNotNullOrEmpty]
        public bool? EnableAccount { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "New password for the user.")]
        [ValidateNotNullOrEmpty]
        [Obsolete("Set-AzureRmADUser: The parameter \"Password\" is being changed from a string to a SecureString in an upcoming breaking change release.")]
        public SecureString Password { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "It must be specified if the user should change the password on the next successful login. Only valid if password is updated otherwise it will be ignored.")]
        public SwitchParameter ForceChangePasswordNextLogin { get; set; }

        public override void ExecuteCmdlet()
        {
            PasswordProfile profile = null;
            string decodedPassword = Utilities.SecureStringToString(Password);
#pragma warning disable 0618
            if (!string.IsNullOrEmpty(decodedPassword))
#pragma warning restore 0618
            {
                profile = new PasswordProfile
                {
#pragma warning disable 0618
                    Password = decodedPassword,
#pragma warning restore 0618
                    ForceChangePasswordNextLogin = ForceChangePasswordNextLogin.IsPresent ? true : false
                };
            }

            var userUpdateParameters = new UserUpdateParameters(EnableAccount, DisplayName, profile);

            ExecutionBlock(() =>
            {
                if (ShouldProcess(target: UPNOrObjectId, action: string.Format("Updating properties for user with upn or object id '{0}'", UPNOrObjectId)))
                {
                    WriteObject(ActiveDirectoryClient.UpdateUser(UPNOrObjectId, userUpdateParameters));
                }
            });
        }
    }
}
