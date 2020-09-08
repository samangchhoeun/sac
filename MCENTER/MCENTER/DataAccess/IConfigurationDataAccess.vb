Public Interface IConfigurationDataAccess(Of T)
    Function GetConfig() As T
    Sub Save(ByVal Configuration As T)
    Sub Delete()
End Interface