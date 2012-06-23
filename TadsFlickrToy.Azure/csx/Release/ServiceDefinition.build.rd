<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="TadsFlickrToy.Azure" generation="1" functional="0" release="0" Id="142d3ce0-2a9a-47e3-a088-73377b3d6548" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="TadsFlickrToy.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="TadsFlickrToy:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/TadsFlickrToy.Azure/TadsFlickrToy.AzureGroup/LB:TadsFlickrToy:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="TadsFlickrToy:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/TadsFlickrToy.Azure/TadsFlickrToy.AzureGroup/MapTadsFlickrToy:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="TadsFlickrToyInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/TadsFlickrToy.Azure/TadsFlickrToy.AzureGroup/MapTadsFlickrToyInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:TadsFlickrToy:Endpoint1">
          <toPorts>
            <inPortMoniker name="/TadsFlickrToy.Azure/TadsFlickrToy.AzureGroup/TadsFlickrToy/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapTadsFlickrToy:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/TadsFlickrToy.Azure/TadsFlickrToy.AzureGroup/TadsFlickrToy/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapTadsFlickrToyInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/TadsFlickrToy.Azure/TadsFlickrToy.AzureGroup/TadsFlickrToyInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="TadsFlickrToy" generation="1" functional="0" release="0" software="C:\Users\Tad\Documents\Visual Studio 2010\Projects\TadsFlickrToy\TadsFlickrToy.Azure\csx\Release\roles\TadsFlickrToy" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;TadsFlickrToy&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;TadsFlickrToy&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/TadsFlickrToy.Azure/TadsFlickrToy.AzureGroup/TadsFlickrToyInstances" />
            <sCSPolicyFaultDomainMoniker name="/TadsFlickrToy.Azure/TadsFlickrToy.AzureGroup/TadsFlickrToyFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="TadsFlickrToyFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="TadsFlickrToyInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="5d9c8ba0-4b97-4f1b-bb13-aa176b827291" ref="Microsoft.RedDog.Contract\ServiceContract\TadsFlickrToy.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="f3fbacb7-a787-40bf-b006-753a13ae527c" ref="Microsoft.RedDog.Contract\Interface\TadsFlickrToy:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/TadsFlickrToy.Azure/TadsFlickrToy.AzureGroup/TadsFlickrToy:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>