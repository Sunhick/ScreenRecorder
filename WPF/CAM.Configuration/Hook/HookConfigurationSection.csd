<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="12c20ab2-3fcb-42b7-8933-a29b2f008d6d" namespace="CAM.Configuration" xmlSchemaNamespace="urn:CAM.Configuration" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="Hook" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="hook">
      <elementProperties>
        <elementProperty name="Commands" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="commands" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/12c20ab2-3fcb-42b7-8933-a29b2f008d6d/Commands" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="Executable">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/12c20ab2-3fcb-42b7-8933-a29b2f008d6d/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="ExeLocation" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="exeLocation" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/12c20ab2-3fcb-42b7-8933-a29b2f008d6d/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="Arguments">
      <attributeProperties>
        <attributeProperty name="CommandLine" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="commandLine" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/12c20ab2-3fcb-42b7-8933-a29b2f008d6d/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="Commands" xmlItemName="command" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationSectionMoniker name="/12c20ab2-3fcb-42b7-8933-a29b2f008d6d/Command" />
      </itemType>
    </configurationElementCollection>
    <configurationSection name="Command" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="command">
      <attributeProperties>
        <attributeProperty name="HookId" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="hookId" isReadOnly="true">
          <type>
            <externalTypeMoniker name="/12c20ab2-3fcb-42b7-8933-a29b2f008d6d/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Mode" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="mode" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/12c20ab2-3fcb-42b7-8933-a29b2f008d6d/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Executable" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="executable" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/12c20ab2-3fcb-42b7-8933-a29b2f008d6d/Executable" />
          </type>
        </elementProperty>
        <elementProperty name="Arguments" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="arguments" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/12c20ab2-3fcb-42b7-8933-a29b2f008d6d/Arguments" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>