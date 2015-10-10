/**
 * No License Applied.
 * Can be used freely.
 *
 * HouYu Li <lihouyu (at) phpex.net> 2015/9/29 18:52
 */
using System;
using System.Configuration;
using System.Windows.Forms;

namespace TOTPGen
{
    /// <summary>
    /// The TOTPSecet section for storing account information
    /// </summary>
    public class TOTP_Secret : ConfigurationSection
    {
        public static string sTOTPSection = "TOTPSecret";
        
        public static TOTP_Secret GetConfig()
        {
            return (TOTP_Secret)ConfigurationManager.GetSection(TOTP_Secret.sTOTPSection) ??
                new TOTP_Secret();
        }
        
        [ConfigurationProperty("TOTPAccounts")]
        public TOTP_SecretInfoCollection TOTPAccounts
        {
            get {
                return (TOTP_SecretInfoCollection)this["TOTPAccounts"] ??
                    new TOTP_SecretInfoCollection();
            }
        }
    }
    
    /// <summary>
    /// The TOTP account information
    /// </summary>
    public class TOTP_SecretInfo : ConfigurationElement
    {
        private ToolStripMenuItem _tsMenu;
        
        public ToolStripMenuItem MenuItem {
            get {
                return this._tsMenu;
            }
            set {
                this._tsMenu = value;
            }
        }
        
        [ConfigurationProperty("Key", DefaultValue = "0000000000000000", IsRequired = true)]
        public string Key {
            get {
                return (string)this["Key"];
            }
            set {
                this["Key"] = value;
            }
        }
        
        [ConfigurationProperty("ID", DefaultValue = "Default", IsRequired = true)]
        public string ID {
            get {
                return (string)this["ID"];
            }
            set {
                this["ID"] = value;
            }
        }
        
        [ConfigurationProperty("CodeLen", DefaultValue = "6", IsRequired = true)]
        public int CodeLen {
            get {
                return (int)this["CodeLen"];
            }
            set {
                this["CodeLen"] = value;
            }
        }
    }
    
    /// <summary>
    /// The collection that holds all TOTP accounts
    /// </summary>
    public class TOTP_SecretInfoCollection : ConfigurationElementCollection
    {
        public TOTP_SecretInfo this[int index]
        {
            get {
                return base.BaseGet(index) as TOTP_SecretInfo;
            }
            set {
                if (base.BaseGet(index) != null) {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }
        
        protected override ConfigurationElement CreateNewElement()
        {
            return new TOTP_SecretInfo();
        }
        
        public void Add(TOTP_SecretInfo secinfo)
        {
            this.BaseAdd(secinfo);
        }
        
        public TOTP_SecretInfo FindByID(string ID)
        {
            return (TOTP_SecretInfo)base.BaseGet(ID);
        }
        
        public bool RemoveByID(string ID)
        {
            try {
                base.BaseRemove(ID);
            } catch (Exception e) {
                return false;
            }
            
            return true;
        }
        
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TOTP_SecretInfo)element).ID;
        }
    }
}
