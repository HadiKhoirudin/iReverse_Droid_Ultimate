Namespace Bismillah.FIREHOSE
    Public NotInheritable Class PACKET
        Public xml As String
        Public Shared Function pkt_fhConfig(MemName As String) As String
            Dim config = New FIREHOSE_CONFIG With {.Version = 4, .MemoryName = MemName, .SkipWrite = 0, .ZLPAwareHost = 1, .SkipStorageInit = 0, .ActivePartition = 0, .MaxPayloadSizeToTargetInBytes = 8192, .AckRawDataEveryNumPackets = 1}
            Dim x As String = $"<?xml version = ""1.0""?><data><configure MemoryName=""{config.MemoryName}"" ZLPAwareHost=""{config.ZLPAwareHost}"" SkipStorageInit=""{config.SkipStorageInit}"" SkipWrite=""{config.SkipWrite}"" MaxPayloadSizeToTargetInBytes=""{config.MaxPayloadSizeToTargetInBytes}""/></data>"

            Return x
        End Function
        Public Shared Function pkt_setAckRaw(val As Integer) As String
            Dim x = $"<?xml version=""1.0"" ?><data><configure AckRawData=""{val}""/></data>"
            Return x
        End Function
        Public Shared Function pkt_peekMem(address64 As UInteger, size As Integer) As String
            Dim x = $" <?xml version=""1.0"" ?><data><peek address64=""{address64}"" SizeInBytes=""{size}""/></data>"
            Return x
        End Function


        Public Shared Function pkt_eMMCinfo(drive As String) As String
            Dim x = $"<?xml version=""1.0"" ?><data><getstorageinfo physical_partition_number=""{drive}""/></data>"
            Return x
        End Function
        Public Shared Function pkt_ProgramUFS(nPartSectors As Integer, fileName As String, startSector As Integer, lun As Integer) As String
            Dim x = $" <?xml version=""1.0"" ?><data><program SECTOR_SIZE_IN_BYTES=""4096"" filename=""{fileName}"" num_partition_sectors=""{nPartSectors}"" physical_partition_number=""0"" start_sector=""{lun}""/></data>"
            Return x
        End Function


        Public Shared Function BootConf() As String
            Dim pkt As String = "<?xml version=""1.0"" ?><data><setbootablestoragedrive value=""0"" /></data>"
            Return pkt
        End Function
        'Only in 5044R
        Public Shared Function pkt_readSecBoot() As String
            Dim pkt As String = "<?xml version=""1.0"" ?><data><getSecureBootStatus/></data>"
            Return pkt
        End Function
        'DOES NOT WORK -- DEPRECIATED?? Read from RAM instead.
        Public Shared Function pkt_readSerialNumber() As String
            Dim pkt As String = "<?xml version=""1.0"" ?><data><getserialnum /></data>"
            Return pkt
        End Function
        Public Shared Function pkt_readIMEI() As String
            Dim pkt As String = "<?xml version=""1.0"" ?><data><readIMEI len=""32""/></data>"
            Return pkt
        End Function
        Public Shared Function pkt_sendNop() As String
            Dim nop_pkt As String = "<?xml version=""1.0"" ?><data><nop /></data>"
            Return nop_pkt
        End Function
        Public Shared Function pkt_sendReset() As String
            Dim reset_pkt As String = "<?xml version=""1.0"" ?><data><power value=""reset""/></data>"
            Return reset_pkt
        End Function
        Public Shared Function pkt_read(sectorSize As Integer, numPartitionSectors As Integer, physicalPartNum As Integer, startSector As String) As String
            Dim x = $"<?xml version = ""1.0""?><data><read SECTOR_SIZE_IN_BYTES=""{sectorSize}"" num_partition_sectors=""{numPartitionSectors}"" physical_partition_number=""{physicalPartNum}"" start_sector=""{startSector}""/></data>"
            Return x
        End Function
        Public Shared Function pkt_Program(sectorsize As String, NumPartitionSector As String, PhysicalPartition As String, StartSector As String) As String
            Dim x = $"<?xml version = ""1.0""?><data><program SECTOR_SIZE_IN_BYTES=""{sectorsize}"" file_sector_offset=""0"" num_partition_sectors=""{NumPartitionSector}""  physical_partition_number=""{PhysicalPartition}"" start_sector=""{StartSector}""/></data>"
            Return x
        End Function
        Public Shared Function pkt_fhloaderRead(sectorsize As String, filename As String, label As String, NumPartitionSector As String, PhysicalPartition As String, StartSector As String) As String
            Dim x = $"<?xml version = ""1.0""?><data><program SECTOR_SIZE_IN_BYTES=""{sectorsize}"" file_sector_offset=""0"" filename=""{filename}"" label=""{label}"" num_partition_sectors=""{NumPartitionSector}""  physical_partition_number=""{PhysicalPartition}"" start_sector=""{StartSector}""/></data>"
            Return x
        End Function
        Public Shared Function pkt_patch(SectorSize As String, BytesOffset As String, FileName As String, PhysicalPartition As String, SizeInBytes As String, StartSector As String, Value As String, What As String) As String
            Dim x = $"<?xml version = ""1.0""?><data><patch SECTOR_SIZE_IN_BYTES=""{SectorSize}"" byte_offset=""{BytesOffset}"" filename=""{FileName}"" physical_partition_number=""{PhysicalPartition}"" size_in_bytes=""{SizeInBytes}"" start_sector=""{StartSector}"" value=""{Value}"" what=""{What}""/></data>"
            Return x
        End Function
        Public Shared Function pkt_erase(sectorSize As String, numPartitionSectors As String, physicalPartNum As String, startSector As String) As String
            Dim x = $"<?xml version = ""1.0""?><data><erase SECTOR_SIZE_IN_BYTES=""{sectorSize}"" num_partition_sectors=""{numPartitionSectors}"" physical_partition_number=""{physicalPartNum}"" start_sector=""{startSector}""/></data>"
            Return x
        End Function


        Public Structure FIREHOSE_CONFIG
            Public Version As Integer
            Public MemoryName As String
            Public SkipWrite As Integer
            Public SkipStorageInit As Integer
            Public ZLPAwareHost As Integer
            Public ActivePartition As Integer
            Public MaxPayloadSizeToTargetInBytes As Integer
            Public AckRawDataEveryNumPackets As Integer
            Public maxPayloadSizeFromTargetInBytes As Integer
        End Structure
    End Class
End Namespace