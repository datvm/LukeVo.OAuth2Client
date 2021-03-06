﻿using LukeVo.OAuth2Client.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LukeVo.OAuth2Client.Test.Services
{

    [TestClass]
    public class FacebookOAuth2ClientTest
    {

        private FacebookOAuth2Client client;

        private TestSettings settings;
        private TestSettings.OAuthConfigs.OAuthClientConfig facebookSettings;
        private OAuth2ClientConfig facebookClientConfig;

        private OAuth2ClientBuilder builder;


        [TestInitialize]
        public void Initialize()
        {
            this.settings = TestSettings.Instance;
            this.facebookSettings = settings.OAuth.Facebook;
            this.facebookClientConfig = ServicesClientConfigs.Facebook;

            this.builder = settings.OAuth.Facebook.ToBuilder();
            this.client = new FacebookOAuth2Client(this.builder);
        }

        [TestMethod]
        public async Task CreateRequestUriAsyncTest1()
        {
            var result = await this.client.CreateRequestUriAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(this.facebookClientConfig.AuthorizationEndpoint.Host, result.Host);

            var parameters = result.ParseQueryString();
            Assert.AreEqual(this.facebookSettings.ClientId, parameters["client_id"]);
            Assert.AreEqual(this.facebookSettings.RedirectUri, parameters["redirect_uri"]);
            Assert.IsNotNull(parameters["state"]);
        }

        [TestMethod]
        public async Task CreateRequestUriAsyncTest2()
        {
            const string overrideRedirectUri = "https://www.example.com/";
            const string state = "123";

            var result = await this.client.CreateRequestUriAsync(new OAuth2UriRequestOptions()
            {
                CustomParameters = new Dictionary<string, string>() { { "testParam", "123" } },
                OverrideRedirectUri = new Uri(overrideRedirectUri),
                State = state,
            });

            Assert.IsNotNull(result);
            Assert.AreEqual(this.facebookClientConfig.AuthorizationEndpoint.Host, result.Host);

            var parameters = result.ParseQueryString();
            Assert.AreEqual(this.facebookSettings.ClientId, parameters["client_id"]);
            Assert.AreEqual(overrideRedirectUri, parameters["redirect_uri"]);
            Assert.AreEqual(state, parameters["state"]);
            Assert.AreEqual("123", parameters["testParam"]);
        }

        [TestMethod]
        public async Task RequestAccessTokenAsyncTest()
        {

        }

    }

}
