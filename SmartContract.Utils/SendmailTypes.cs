using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public class SendmailTypes
    {
        /// <summary>
        /// หน่วยริการ : ผู้มีอำนาจลงนาม
        /// </summary>
        public const String VendorAuthority = "SN11";
        /// <summary>
        /// หน่วยริการ : พยานลงนาม
        /// </summary>
        public const String VendorWitness = "SN12";
        /// <summary>
        /// สปสช : ผู้มีอำนาจลงนาม
        /// </summary>
        public const String NhsoAuthority = "SN21";
        /// <summary>
        /// สปสช : พยานลงนาม
        /// </summary>
        public const String NhsoWitness = "SN22";
        /// <summary>
        /// สปสช : ผู้มีอำนาจลงนาม(ลงนามกาะดาษ)
        /// </summary>
        public const String NhsoAuthorityP = "SN41";
        /// <summary>
        /// สปสช : พยานลงนาม(ลงนามกาะดาษ)
        /// </summary>
        public const String NhsoWitnessP = "SN42";
    }
}
