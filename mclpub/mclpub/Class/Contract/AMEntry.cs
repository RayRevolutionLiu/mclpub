using System;
using System.Collections.Generic;

using System.Web;

namespace mclpub
{
    public class AMEntry
    {
        // Fields
        private int _cls1id;
        private int _cls2id;
        private int _cls3id;
        private string _contno;

        public AMEntry()
        {

        }

        public int Cls1Id
        {
            get
            {
                return this._cls1id;
            }
            set
            {
                this._cls1id = value;
            }
        }

        public int Cls2Id
        {
            get
            {
                return this._cls2id;
            }
            set
            {
                this._cls2id = value;
            }
        }

        public int Cls3Id
        {
            get
            {
                return this._cls3id;
            }
            set
            {
                this._cls3id = value;
            }
        }

        public string ContNo
        {
            get
            {
                return this._contno;
            }
            set
            {
                this._contno = value;
            }
        }
 

 
        public AMEntry(string contno, int cls1id, int cls2id, int cls3id)
        {
            if (((contno == null) || (contno.Trim() == "")) || (contno.Length != 6))
            {
                throw new Exception("新生資料的合約編號不可為null、空字串，或者長度不符");
            }
            this._contno = contno;
            this._cls1id = cls1id;
            this._cls2id = cls2id;
            this._cls3id = cls3id;
        }


    }


}
