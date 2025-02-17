﻿#region Apache License Version 2.0
/*----------------------------------------------------------------

Copyright 2025 Jeffrey Su & Suzhou Senparc Network Technology Co.,Ltd.

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the
License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
either express or implied. See the License for the specific language governing permissions
and limitations under the License.

Detail: https://github.com/JeffreySu/WeiXinMPSDK/blob/master/license.md

----------------------------------------------------------------*/
#endregion Apache License Version 2.0

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Senparc.Weixin.Work.Entities;
using Senparc.Weixin.Work.Test.CommonApis;
using Senparc.Weixin.Work.Test.net6.MessageHandlers;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Senparc.Weixin.Work.Test.MessageHandlers
{
    [TestClass]
    public partial class WorkMessageHandlersTest : CommonApiTest
    {
        private string testXml = @"<xml><ToUserName><![CDATA[wx7618c0a6d9358622]]></ToUserName>
<Encrypt><![CDATA[h3z+AK9zKP4dYs8j1FmthAILbJghEmdo2Y1U9Pdghzann6H2KJOpepaDT1zcp09/1/e/6ta48aUXebkHlu0rhzk4GW+cvVUHzbEiQVFlIvD+q4T/NLIm8E8BM+gO+DHslM7aXmYjvgMw6AYiBx80D+nZKNyJD3I8lRT3aHCq/hez0c+HTAnZyuCi5TfUAw0c6jWSfAq61VesRw4lhV925vJUOBXT/zOw760CEsYXSr2IAr/n4aPfDgRs2Ww2h/HPiVOQ2Ms1f/BOtFiKVWMqZCxbmJ7cyPHH7+uOSAS6DtXiQAdwpEZwHz+A5QTsmK6V0C6Ifgr7zrStb7ygM7kmcrAJctPhCfG7WlfrWrFNLdtx9Q2F7d6/soinswdoYF8g56s8UWguOVkM7UFGr8H2QqrUJm5S5iFP/XNcBwvPWYA=]]></Encrypt>
<AgentID><![CDATA[2]]></AgentID>
</xml>";


        private string testXml2 = @"<xml><ToUserName><![CDATA[tj99bf85a7c6525277]]></ToUserName><Encrypt><![CDATA[mOYGyroKLkpIDLNn6DAPjdZbRsQlkUggk+LnYY2S/7O/nRxxu3hDsJLiod29NVMYpwVNHMqTnZALXmycI6c7+wWxway/T/91okclPXn+EB/u4vss5FKntesFMxtGPRxt1aChMN9yNJNRhom05UD4c3B3lSicS10LE3MwWenb9t3CzbovlwM7T9jq1PFOA/0HyGZtwIoNdPjc0xaPe09oMvRtn69vu7whudjq2oI27jmEvXAfrWxN29oYTb+dPmBgXx/y4Hs2nWctuiCS7l9jN/dgzKTfPP056k7AKp49XIe2PHJZsmq/jhKLh+7aVRjGcWQepgshtbRwNtolPsT3AoblAa/be7d3igl/EbfguPTK/mAANEb73grwQxfNVH/MJr4sQrTKn/DHjbP9GyoKrr6qFxpDiziZB7LD/kvUqSw=]]></Encrypt><AgentID><![CDATA[]]></AgentID></xml>";

        [TestMethod]
        public async Task TextTest()
        {
            var postModel = new PostModel()
            {
                Msg_Signature = "118b034be74c917464f833cd32fc3f74958b2c93",
                Timestamp = "1505643268",
                Nonce = "1504921331",

                Token = "3J5JTpb4j8Yfk",
                EncodingAESKey = "XtJUgDlFYncPP3z4V7W6Jv4ietcIFveUn6LP1KzOBNf",
                CorpId = base._corpId
            };
            var messageHandler = new CustomMessageHandlers(XDocument.Parse(testXml), postModel, 10);
            Assert.IsNotNull(messageHandler.RequestDocument);
            Assert.IsNotNull(messageHandler.RequestMessage);
            Assert.IsNotNull(messageHandler.EncryptPostData);
            Assert.IsTrue(messageHandler.AgentId == 2);

            await messageHandler.ExecuteAsync(new CancellationToken());

            Assert.IsNotNull(messageHandler.ResponseDocument);
            Assert.IsNotNull(messageHandler.ResponseMessage);

            Console.WriteLine(messageHandler.RequestDocument);
        }

        [TestMethod]
        public async Task TextTest2()
        {
            var postModel = new PostModel()
            {
                Msg_Signature = "118b034be74c917464f833cd32fc3f74958b2c93",
                Timestamp = "1505643268",
                Nonce = "1504921331",

                Token = "3J5JTpb4j8Yfk",
                EncodingAESKey = "XtJUgDlFYncPP3z4V7W6Jv4ietcIFveUn6LP1KzOBNf",
                CorpId = base._corpId
            };
            var messageHandler = new CustomMessageHandlers(XDocument.Parse(testFileXml), postModel, 10);
            Assert.IsNotNull(messageHandler.RequestDocument);
            Assert.IsNotNull(messageHandler.RequestMessage);
            Assert.IsNotNull(messageHandler.EncryptPostData);
            Assert.IsTrue(messageHandler.AgentId == 2);

            await messageHandler.ExecuteAsync(new CancellationToken());

            Assert.IsNotNull(messageHandler.ResponseDocument);
            Assert.IsNotNull(messageHandler.ResponseMessage);


            Console.WriteLine(messageHandler.RequestDocument);
        }


        private string testFileXml = @"<xml>
    <ToUserName>
        <![CDATA[gh_ffffeeeedddd]]>
    </ToUserName>
    <FromUserName>
        <![CDATA[o5lE40xwHOqG8riO_EOZQV3JYCV8]]>
    </FromUserName>
    <CreateTime>1518080539</CreateTime>
    <MsgType>
        <![CDATA[file]]>
    </MsgType>
    <Title>
        <![CDATA[小冰 piano.wav]]>
    </Title>
    <Description>
        <![CDATA[]]>
    </Description>
    <FileKey>
        <![CDATA[AwAAAAAAAABF4n55]]>
    </FileKey>
    <FileMd5>
        <![CDATA[07bee1c012c5ef718514701d42fae10c]]>
    </FileMd5>
    <FileTotalLen>10203788</FileTotalLen>
    <MsgId>6520106268131360945</MsgId>
    <Encrypt>
        <![CDATA[LDlJIR3WMDZ3b3zg7UqmLMJ1fTH/rj7Hr55nfmzfamX4BgSOTScY/5ZoDYzb2esTHFuHNVpqyyFwGjlxVmIAPrh+bTK80APcklA9dCiV4TWAppittpITkktJ1e5KPjJ6GEEPdmq2Fqipd0tfzgLH7Q0F68+PSc3XSbbEvV1fSeccJ2FIZxoikIRO/UZX101BK7cHY/Zn+H3DeDcCDA/0SFg5JrIlWONOY72SEiUkl9Edo4GwrQqN5y6u0zh/apKbi3B6S4xk3Z/66rnFjPS+zN7bT/URCpEDZShUHJqVPa//7BnTm51IvTchTlm01MdM5UCh6pHTuoNrTGmwAy/4ekCGjmD6bcbJbQ7c3D2uH8ej9cKc+xMfEuZkxbHC5I9t6xhPBoZ0L4cvSZGTTu+1Pd/sF4I3lkdBOn2U4dcO7NzacJM3vmSY7hVMOw3eRJhI0nlaiM1mrfO3A8EJouS9nkYAnQyYbV14rscdARVO5f4ipS8336soC00ZbRgmVgKfIpE4phxJMDmiux7ym7s40dwD9WNtxXK4Zk4ePQGrvjLvrx2PbZIUpV//Aing1oS9Lh6OdVhJgFlBd7bs0HlccbhADiYR07k+eG8TdaUNoDKdkXNgYgxGwUpB07e0vfuD2EtIpI0P/b7QrJU1nAw2R/s3imfLmStVlq3CRpTo5ahnhNrSZ8db/hEM3XJsIotVRUQKT4ONFvnI7RLLGWjkNQ==]]>
     </Encrypt>
</xml>
";
        //<Encrypt>
        //     <![CDATA[LDlJIR3WMDZ3b3zg7UqmLMJ1fTH/rj7Hr55nfmzfamX4BgSOTScY/5ZoDYzb2esTHFuHNVpqyyFwGjlxVmIAPrh+bTK80APcklA9dCiV4TWAppittpITkktJ1e5KPjJ6GEEPdmq2Fqipd0tfzgLH7Q0F68+PSc3XSbbEvV1fSeccJ2FIZxoikIRO/UZX101BK7cHY/Zn+H3DeDcCDA/0SFg5JrIlWONOY72SEiUkl9Edo4GwrQqN5y6u0zh/apKbi3B6S4xk3Z/66rnFjPS+zN7bT/URCpEDZShUHJqVPa//7BnTm51IvTchTlm01MdM5UCh6pHTuoNrTGmwAy/4ekCGjmD6bcbJbQ7c3D2uH8ej9cKc+xMfEuZkxbHC5I9t6xhPBoZ0L4cvSZGTTu+1Pd/sF4I3lkdBOn2U4dcO7NzacJM3vmSY7hVMOw3eRJhI0nlaiM1mrfO3A8EJouS9nkYAnQyYbV14rscdARVO5f4ipS8336soC00ZbRgmVgKfIpE4phxJMDmiux7ym7s40dwD9WNtxXK4Zk4ePQGrvjLvrx2PbZIUpV//Aing1oS9Lh6OdVhJgFlBd7bs0HlccbhADiYR07k+eG8TdaUNoDKdkXNgYgxGwUpB07e0vfuD2EtIpI0P/b7QrJU1nAw2R/s3imfLmStVlq3CRpTo5ahnhNrSZ8db/hEM3XJsIotVRUQKT4ONFvnI7RLLGWjkNQ==]]>
        // </Encrypt>
        [TestMethod]
        public void FileTest()
        {
            //数据不全，未开始正式测试
            var postModel = new PostModel()
            {
                Msg_Signature = "118b034be74c917464f833cd32fc3f74958b2c93",
                Timestamp = "1505643268",
                Nonce = "1504921331",

                Token = "3J5JTpb4j8Yfk",
                EncodingAESKey = "XtJUgDlFYncPP3z4V7W6Jv4ietcIFveUn6LP1KzOBNf",
                CorpId = ""
            };

            var messageHandler = new CustomMessageHandlers(XDocument.Parse(testFileXml), postModel, 10);

        }


    }
}
