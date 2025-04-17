﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace VideoGameDatabaseTest.Features.V2
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("UpdateVideoGameV2")]
    [NUnit.Framework.FixtureLifeCycleAttribute(NUnit.Framework.LifeCycle.InstancePerTestCase)]
    public partial class UpdateVideoGameV2Feature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/V2", "UpdateVideoGameV2", "As a user, I want to be able to make a PUT request to the \'/api/v2/videogame/{id}" +
                "\' end point \r\ncontaining a JSON object matching an existing video game in order " +
                "to update that \r\nvideo game\'s details.", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "UpdateVideoGameV2.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check various valid and invalid IDs with valid authorisation")]
        [NUnit.Framework.TestCaseAttribute("-1", "404", null)]
        [NUnit.Framework.TestCaseAttribute("0", "404", null)]
        [NUnit.Framework.TestCaseAttribute("1", "200", null)]
        [NUnit.Framework.TestCaseAttribute("9", "200", null)]
        [NUnit.Framework.TestCaseAttribute("10", "200", null)]
        [NUnit.Framework.TestCaseAttribute("11", "404", null)]
        public async System.Threading.Tasks.Task CheckVariousValidAndInvalidIDsWithValidAuthorisation(string iD, string status_Code, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("ID", iD);
            argumentsOfScenario.Add("status_code", status_Code);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Check various valid and invalid IDs with valid authorisation", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 8
 await testRunner.GivenAsync(string.Format("I create a PUT request with valid authorisation with an ID of {0}", iD), ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 9
 await testRunner.AndAsync("my PUT request content is formatted correctly", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 10
 await testRunner.WhenAsync("I send the PUT request to the specified endpoint", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 11
 await testRunner.ThenAsync(string.Format("I receive a status code of {0}", status_Code), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 12
 await testRunner.AndAsync("The PUT request response JSON content is formatted correctly", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check various valid and invalid IDs with invalid authorisation")]
        [NUnit.Framework.TestCaseAttribute("0", "403", null)]
        [NUnit.Framework.TestCaseAttribute("6", "403", null)]
        [NUnit.Framework.TestCaseAttribute("11", "403", null)]
        public async System.Threading.Tasks.Task CheckVariousValidAndInvalidIDsWithInvalidAuthorisation(string iD, string status_Code, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("ID", iD);
            argumentsOfScenario.Add("status_code", status_Code);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Check various valid and invalid IDs with invalid authorisation", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 22
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 23
 await testRunner.GivenAsync(string.Format("I create a PUT request with invalid authorisation with an ID of {0}", iD), ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 24
 await testRunner.AndAsync("my PUT request content is formatted correctly", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 25
 await testRunner.WhenAsync("I send the PUT request to the specified endpoint", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 26
 await testRunner.ThenAsync(string.Format("I receive a status code of {0}", status_Code), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check valid ID response with valid authorisation but invalid request JSON content" +
            "")]
        public async System.Threading.Tasks.Task CheckValidIDResponseWithValidAuthorisationButInvalidRequestJSONContent()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Check valid ID response with valid authorisation but invalid request JSON content" +
                    "", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 33
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 34
 await testRunner.GivenAsync("I create a PUT request with valid authorisation with an ID of 1", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 35
 await testRunner.AndAsync("my PUT request content is formatted incorrectly", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 36
 await testRunner.WhenAsync("I send the PUT request to the specified endpoint", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 37
 await testRunner.ThenAsync("I receive a response with a 400 Bad Request error code", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
