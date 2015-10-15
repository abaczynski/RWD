<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="PurpleBricksDemo.Web.Azure" generation="1" functional="0" release="0" Id="84ad192e-1f6f-49ae-8313-b92e56ec9c70" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="PurpleBricksDemo.Web.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="PurpleBricksDemo.Web:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/PurpleBricksDemo.Web.Azure/PurpleBricksDemo.Web.AzureGroup/LB:PurpleBricksDemo.Web:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="PurpleBricksDemo.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/PurpleBricksDemo.Web.Azure/PurpleBricksDemo.Web.AzureGroup/MapPurpleBricksDemo.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="PurpleBricksDemo.WebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/PurpleBricksDemo.Web.Azure/PurpleBricksDemo.Web.AzureGroup/MapPurpleBricksDemo.WebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:PurpleBricksDemo.Web:Endpoint1">
          <toPorts>
            <inPortMoniker name="/PurpleBricksDemo.Web.Azure/PurpleBricksDemo.Web.AzureGroup/PurpleBricksDemo.Web/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapPurpleBricksDemo.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/PurpleBricksDemo.Web.Azure/PurpleBricksDemo.Web.AzureGroup/PurpleBricksDemo.Web/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapPurpleBricksDemo.WebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/PurpleBricksDemo.Web.Azure/PurpleBricksDemo.Web.AzureGroup/PurpleBricksDemo.WebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="PurpleBricksDemo.Web" generation="1" functional="0" release="0" software="C:\Users\User\Documents\Visual Studio 2012\Projects\PurpleBricksDemo\PurpleBricksDemo.Web.Azure\csx\Debug\roles\PurpleBricksDemo.Web" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;PurpleBricksDemo.Web&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;PurpleBricksDemo.Web&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/PurpleBricksDemo.Web.Azure/PurpleBricksDemo.Web.AzureGroup/PurpleBricksDemo.WebInstances" />
            <sCSPolicyUpdateDomainMoniker name="/PurpleBricksDemo.Web.Azure/PurpleBricksDemo.Web.AzureGroup/PurpleBricksDemo.WebUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/PurpleBricksDemo.Web.Azure/PurpleBricksDemo.Web.AzureGroup/PurpleBricksDemo.WebFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="PurpleBricksDemo.WebUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="PurpleBricksDemo.WebFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="PurpleBricksDemo.WebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="b62b5ea5-4e75-4f5c-a717-f106ace6016e" ref="Microsoft.RedDog.Contract\ServiceContract\PurpleBricksDemo.Web.AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="c5476403-977a-4a76-ba0f-9b8e1d4a3a4f" ref="Microsoft.RedDog.Contract\Interface\PurpleBricksDemo.Web:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/PurpleBricksDemo.Web.Azure/PurpleBricksDemo.Web.AzureGroup/PurpleBricksDemo.Web:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>