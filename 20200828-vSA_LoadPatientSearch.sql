		SELECT distinct
			CONVERT(NVARCHAR, RegistrationDate, 107) AS RegistrationDate
			,[PatientCode] 
			,LTRIM(RTRIM(ISNULL(KLastName, '') +' ' + ISNULL(KFirstName, ''))) as [KhmerName]
			,LTRIM(RTRIM(ISNULL(FirstName, '') +' ' + ISNULL(LastName, ''))) as [EnglishName]
			,Gender
			,CONVERT(NVARCHAR, DOB, 107) AS DOB
			,FLOOR(DATEDIFF(DAY, [DOB], GETDATE()) / 365.25) AS Age
			,MaritalStatus 
			,[CellPhone] 
			,O.Occupation as Occupation
			,PT.[PatientType] 
			,[City] as Address
			,P.CardID
			,U.Name as [InputBy]
		FROM tblsa_patients P
			inner join tblsa_patients_type PT on P.PatientTypeID=PT.ID
			inner join tblsa_ms_location_provinces LP on P.CurCity=LP.PID
			left join tblsa_set_userlog U on U.UserNo=P.UserCreate
			left join tblsa_patients_occupation O on P.Occupation=O.OccupationID
		WHERE (P.Mark_Deleted=0 OR P.Mark_Deleted IS NULL)
		ORDER BY [EnglishName]