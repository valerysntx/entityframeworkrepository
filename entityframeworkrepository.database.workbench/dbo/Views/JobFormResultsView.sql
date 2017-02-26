CREATE VIEW dbo.JobFormResultsView
AS
SELECT        JB.IsDeleted, JFR.JobFormID, CVBank.CVBankID, CVBank.CVBankFilename, BOwner.CVBankOwnerID, BOwner.JobFormResultID, CN.FirstName + ' ' + CN.FirstName AS ApplicantName, JFR.CandidateID, 
                         JFR.FirstName + ' ' + JFR.LastName AS ApplicantFakeName, JFR.DateAdded AS DateApplied, JB.JobTitle, JB.JobDescription, PA.FirstName + ' ' + PA.LastName AS JobPosted_Name, 
                         PU.FirstName + ' ' + PU.LastName AS JobUpdatedBy_Name, JB.CreatedBy AS JobCreatedByID, DP.CompanyID, CP.CompanyName, DP.DepartmentID, DC.DictionaryType AS Department
FROM            dbo.JobFormResult AS JFR INNER JOIN
                         dbo.JobForm AS JF ON JFR.JobFormID = JF.JobFormID INNER JOIN
                         dbo.Person AS CN ON CN.PersonID = JFR.CandidateID INNER JOIN
                         dbo.CVBank AS CVBank ON CVBank.CVBankID = JFR.CVBankID INNER JOIN
                         dbo.CVBankOwner AS BOwner ON CVBank.CVBankID = BOwner.CVBankID INNER JOIN
                         dbo.Job AS JB ON JF.JobID = JB.JobID INNER JOIN
                         dbo.Person AS PA ON JB.CreatedBy = PA.PersonID INNER JOIN
                         dbo.Person AS PU ON JB.UpdatedBy = PU.PersonID INNER JOIN
                         dbo.Department AS DP ON DP.PersonID = JB.CreatedBy INNER JOIN
                         dbo.Company AS CP ON CP.CompanyID = DP.CompanyID INNER JOIN
                         dbo.Dictionary AS DC ON DC.DictionaryTypeID = DP.DepartmentID

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'JobFormResultsView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "JFR"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 132
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JF"
            Begin Extent = 
               Top = 6
               Left = 281
               Bottom = 132
               Right = 481
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CN"
            Begin Extent = 
               Top = 6
               Left = 519
               Bottom = 132
               Right = 699
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CVBank"
            Begin Extent = 
               Top = 132
               Left = 38
               Bottom = 258
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BOwner"
            Begin Extent = 
               Top = 132
               Left = 255
               Bottom = 258
               Right = 433
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JB"
            Begin Extent = 
               Top = 132
               Left = 471
               Bottom = 258
               Right = 665
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PA"
            Begin Extent = 
               Top = 258
               Left = 38
               Bottom = 384
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'JobFormResultsView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         End
         Begin Table = "PU"
            Begin Extent = 
               Top = 258
               Left = 256
               Bottom = 384
               Right = 436
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DP"
            Begin Extent = 
               Top = 258
               Left = 474
               Bottom = 384
               Right = 644
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CP"
            Begin Extent = 
               Top = 384
               Left = 38
               Bottom = 510
               Right = 241
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DC"
            Begin Extent = 
               Top = 384
               Left = 279
               Bottom = 510
               Right = 459
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1470
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'JobFormResultsView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'JobFormResultsView';

