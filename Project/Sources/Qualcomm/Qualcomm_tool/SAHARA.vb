Imports System
Imports System.Runtime.InteropServices
Namespace Bismillah.SAHARA
    <Serializable>
    Public Structure SAHARA_HEADER
        Public command As SAHARA_CMD
        Public size As Integer
    End Structure
    Public Structure SAHARA_HEADER64
        Public command As SAHARA_CMD
        Public size As Integer
    End Structure
    Public Structure SAHARA_PBL_INFO
        Public serial As String
        Public msm_id As String
        Public pk_hash As String
        Public pbl_sw As Integer
    End Structure
    Public Enum SAHARA_MODE
        SAHARA_MODE_IMAGE_PENDING = &H0 'IF RESPONDING TO HELLO WITH THIS: SaharaCommandReadData will be returned
        SAHARA_MODE_IMAGE_TX_COMPLETE = &H1
        SAHARA_MODE_MEMDEBUG = &H2
        SAHARA_MODE_COMMAND = &H3 'IF RESPONDING TO HELLO WITH THIS: SaharaCommandReady will be returned
    End Enum
    Public Enum SAHARA_EXEC_CMD
        SAHARA_EXEC_CMD_NOP = &H0
        SAHARA_EXEC_CMD_SERIAL_NUM_READ = &H1
        SAHARA_EXEC_CMD_MSM_HW_ID_READ = &H2
        SAHARA_EXEC_CMD_OEM_PK_HASH_READ = &H3
        SAHARA_EXEC_CMD_SWITCH_TO_DMSS_DLOAD = &H4
        SAHARA_EXEC_CMD_SWITCH_TO_STREAM_DLOAD = &H5
        SAHARA_EXEC_CMD_READ_DEBUG_DATA = &H6
        SAHARA_EXEC_CMD_GET_SOFTWARE_VERSION_SBL = &H7
        ' place all new commands above this 
        SAHARA_EXEC_CMD_LAST
        SAHARA_EXEC_CMD_MAX = &H7FFFFFFF
    End Enum
    '''*********************************************************
    Public Structure SAHARA_REQUESTS_END_IMG_TRSFR_PACKET
        Public header As SAHARA_HEADER
        Private image_id As Integer ' ID of image to be transferred
        Private status As Integer ' OK or error condition
    End Structure
    Public Structure SAHARA_SWITCH_PACKET
        Public header As SAHARA_HEADER
        Public mode As SAHARA_MODE
    End Structure
    Public Structure SAHARA_REQUESTS_IMGDONE_PACKET '0x05
        Public header As SAHARA_HEADER
    End Structure
    Public Structure SAHARA_RESPONSE_IMGDONE_PACKET '0x06
        Public header As SAHARA_HEADER
        Public status As SAHARA_STATUS ' indicates if all images have been
    End Structure
    Public Structure SAHARA_RESPONSE_IMGDONE_PACKET64 '0x06
        Public header As SAHARA_HEADER64
        Public status As SAHARA_STATUS ' indicates if all images have been
    End Structure
    Public Enum SAHARA_CMD
        SAHARA_CMD_HELLO_REQ = &H1 ' Initialize connection and protocol
        SAHARA_CMD_HELLO_RESP = &H2 ' Acknowledge connection/protocol, mode of operation
        SAHARA_CMD_READ_DATA = &H3 ' Read specified number of bytes from host
        SAHARA_CMD_IMG_END_TRSFR = &H4 ' image transfer end / target transfer failure
        SAHARA_CMD_IMG_DONE_REQ = &H5 ' Acknowledgement: image transfer is complete
        SAHARA_CMD_IMG_DONE_RESP = &H6 ' Target is exiting protocol
        SAHARA_RESET_REQ = &H7 ' Instruct target to perform a reset
        SAHARA_RESET_RSP = &H8
        SAHARA_MEMORY_DEBUG = &H9
        SAHARA_CMD_EXECUTE_REQ = &HD ' Indicate to host: to execute a given client command
        SAHARA_CMD_EXECUTE_RESPONSE = &HE ' Indicate to host: target command execution status
        SAHARA_CMD_EXECUTE_DATA = &HF 'Executed the client cmd
        SAHARA_MEMORY_READ = &HA
        SAHARA_CMD_READY = &HB ' Indicate to host: target ready to receive client commands,
        SAHARA_CMD_SWITCH_MODE = &HC ' Switch to a mode defined in enum SAHARA_MODE
        SAHARA_EXECUTE_REQ = &HD
        SAHARA_EXECUTE_RSP = &HE
        SAHARA_EXECUTE_DATA = &HF
        SAHARA_64BIT_MEMORY_DEBUG = &H10
        SAHARA_64BIT_MEMORY_READ = &H11
        SAHARA_64BIT_MEMORY_READ_DATA = &H12
    End Enum
    Public Enum SAHARA_IMAGE_ID
        kMbnImageNone = &H0
        kMbnImageOemSbl = &H1
        kMbnImageAmss = &H2
        kMbnImageOcbl = &H3
        kMbnImageHash = &H4
        kMbnImageAppbl = &H5
        kMbnImageApps = &H6
        kMbnImageHostDl = &H7
        kMbnImageDsp1 = &H8
        kMbnImageFsbl = &H9
        kMbnImageDbl = &HA
        kMbnImageOsbl = &HB
        kMbnImageDsp2 = &HC
        kMbnImageEhostdl = &HD
        SAHARA_IMAGE_FIREHOSE = &HE
        kMbnImageNorprg = &HF
        kMbnImageRamfs1 = &H10
        kMbnImageRamfs2 = &H11
        kMbnImageAdspQ5 = &H12
        kMbnImageAppsKernel = &H13
        kMbnImageBackupRamfs = &H14
        kMbnImageSbl1 = &H15
        kMbnImageSbl2 = &H16
        kMbnImageRpm = &H17
        kMbnImageSbl3 = &H18
        kMbnImageTz = &H19
        kMbnImageSsdKeys = &H1A
        kMbnImageGen = &H1B
        kMbnImageDsp3 = &H1C
        kMbnImageAcdb = &H1D
        kMbnImageWdt = &H1E
        kMbnImageMba = &H1F
        kMbnImageLast = kMbnImageMba
    End Enum
    '''*AFTER PORT IS OPENED, SAHARA SENDS THIS BACK***********
    <Serializable>
    Public Structure SAHARA_REQUESTS_HELLO '0x01
        Public header As SAHARA_HEADER
        Public version As Integer
        Public minVersion As Integer
        Public maxCommandPacketSize As Integer
        Public mode As SAHARA_MODE
        Public res1 As Integer
        Public res2 As Integer
        Public res3 As Integer
        Public res4 As Integer
        Public res5 As Integer
        Public res6 As Integer
    End Structure
    '''***************************************************************
    Public Structure GPT_PARTITION_ENTRY
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=16)>
        Public partType As Guid
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=16)>
        Public partId As Guid
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=8)>
        Public firstLBA As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=8)>
        Public lastLBA As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=72)>
        Public partName As String
    End Structure
    Public Structure SAHARA_REQUESTS_READDATA
        Public header As SAHARA_HEADER
        Public imageID As SAHARA_IMAGE_ID
        Public offset As Integer
        Public size As Integer
    End Structure
    Public Structure SAHARA_REQUESTS_READDATA_64
        Public header As SAHARA_HEADER
        Public imageID As SAHARA_IMAGE_ID
        Public offset As Int64
        Public size As Int64
    End Structure
    Public Structure SAHARA_REQUESTS_IMG_DONE 'OUGOING
        Public header As SAHARA_HEADER
    End Structure

    Public Structure SAHARA_REQUESTS_IMG_DONE64 'OUGOING
        Public header As SAHARA_HEADER64
    End Structure
    <Serializable>
    Public Structure SAHARA_RESPONSE_HELLO '0x02
        Public header As SAHARA_HEADER
        Public version As Integer
        Public minVersion As Integer
        Public status As Integer '0x00
        Public mode As SAHARA_MODE
        Public res1 As Integer
        Public res2 As Integer
        Public res3 As Integer
        Public res4 As Integer
        Public res5 As Integer
        Public res6 As Integer
    End Structure
    Public Structure SAHARA_RESPONSE_EXECCMD_RESPONSE
        Public header As SAHARA_HEADER
        Public cmd As SAHARA_EXEC_CMD
        Public size As Integer
    End Structure
    Public Structure SAHARA_REQUEST_EXE_CMD
        Public header As SAHARA_HEADER
        Public clientCmd As SAHARA_EXEC_CMD
    End Structure
    Public Enum SAHARA_STATUS64
        ' Success
        SAHARA_STATUS_SUCCESS = &H1
        ' Invalid command received in current state
        SAHARA_NAK_INVALID_CMD = &H0
        ' Protocol mismatch between host and target
        SAHARA_NAK_PROTOCOL_MISMATCH = &H2
        ' Invalid target protocol version
        SAHARA_NAK_INVALID_TARGET_PROTOCOL = &H3
        ' Invalid host protocol version
        SAHARA_NAK_INVALID_HOST_PROTOCOL = &H4
        ' Invalid packet size received
        SAHARA_NAK_INVALID_PACKET_SIZE = &H5
        ' Unexpected image ID received
        SAHARA_NAK_UNEXPECTED_IMAGE_ID = &H6
        ' Invalid image header size received
        SAHARA_NAK_INVALID_HEADER_SIZE = &H7
        ' Invalid image data size received
        SAHARA_NAK_INVALID_DATA_SIZE = &H8
        ' Invalid image type received
        SAHARA_NAK_INVALID_IMAGE_TYPE = &H9
        ' Invalid tranmission length
        SAHARA_NAK_INVALID_TX_LENGTH = &HA
        ' Invalid reception length
        SAHARA_NAK_INVALID_RX_LENGTH = &HB
        ' General transmission or reception error
        SAHARA_NAK_GENERAL_TX_RX_ERROR = &HC
        ' Error while transmitting READ_DATA packet
        SAHARA_NAK_READ_DATA_ERROR = &HD
        ' Cannot receive specified number of program headers
        SAHARA_NAK_UNSUPPORTED_NUM_PHDRS = &HE
        ' Invalid data length received for program headers
        SAHARA_NAK_INVALID_PDHR_SIZE = &HF
        ' Multiple shared segments found in ELF image
        SAHARA_NAK_MULTIPLE_SHARED_SEG = &H10
        ' Uninitialized program header location
        SAHARA_NAK_UNINIT_PHDR_LOC = &H11
        ' Invalid destination address
        SAHARA_NAK_INVALID_DEST_ADDR = &H12
        ' Invalid data size receieved in image header
        SAHARA_NAK_INVALID_IMG_HDR_DATA_SIZE = &H13
        ' Invalid ELF header received
        SAHARA_NAK_INVALID_ELF_HDR = &H14
        ' Unknown host error received in HELLO_RESP
        SAHARA_NAK_UNKNOWN_HOST_ERROR = &H15
        ' Timeout while receiving data
        SAHARA_NAK_TIMEOUT_RX = &H16
        ' Timeout while transmitting data
        SAHARA_NAK_TIMEOUT_TX = &H17
        ' Invalid mode received from host
        SAHARA_NAK_INVALID_HOST_MODE = &H18
        ' Invalid memory read access
        SAHARA_NAK_INVALID_MEMORY_READ = &H19
        ' Host cannot handle read data size requested
        SAHARA_NAK_INVALID_DATA_SIZE_REQUEST = &H1A
        ' Memory debug not supported
        SAHARA_NAK_MEMORY_DEBUG_NOT_SUPPORTED = &H1B
        ' Invalid mode switch
        SAHARA_NAK_INVALID_MODE_SWITCH = &H1C
        ' Failed to execute command
        SAHARA_NAK_CMD_EXEC_FAILURE = &H1D
        ' Invalid parameter passed to command execution
        SAHARA_NAK_EXEC_CMD_INVALID_PARAM = &H1E
        ' Unsupported client command received
        SAHARA_NAK_EXEC_CMD_UNSUPPORTED = &H1F
        ' Invalid client command received for data response
        SAHARA_NAK_EXEC_DATA_INVALID_CLIENT_CMD = &H20
        ' Failed to authenticate hash table
        SAHARA_NAK_HASH_TABLE_AUTH_FAILURE = &H21
        ' Failed to verify hash for a given segment of ELF image
        SAHARA_NAK_HASH_VERIFICATION_FAILURE = &H22
        ' Failed to find hash table in ELF image
        SAHARA_NAK_HASH_TABLE_NOT_FOUND = &H23
        ' Place all new error codes above this
        SAHARA_NAK_LAST_CODE
        SAHARA_NAK_MAX_CODE = &H7FFFFFFF ' To ensure 32-bits wide
    End Enum


    Public Enum SAHARA_STATUS
        ' Success
        SAHARA_STATUS_32 = &H0
        ' Invalid command received in current state
        SAHARA_STATUS_64 = &H1
        ' Protocol mismatch between host and target
        SAHARA_NAK_PROTOCOL_MISMATCH = &H2
        ' Invalid target protocol version
        SAHARA_NAK_INVALID_TARGET_PROTOCOL = &H3
        ' Invalid host protocol version
        SAHARA_NAK_INVALID_HOST_PROTOCOL = &H4
        ' Invalid packet size received
        SAHARA_NAK_INVALID_PACKET_SIZE = &H5
        ' Unexpected image ID received
        SAHARA_NAK_UNEXPECTED_IMAGE_ID = &H6
        ' Invalid image header size received
        SAHARA_NAK_INVALID_HEADER_SIZE = &H7
        ' Invalid image data size received
        SAHARA_NAK_INVALID_DATA_SIZE = &H8
        ' Invalid image type received
        SAHARA_NAK_INVALID_IMAGE_TYPE = &H9
        ' Invalid tranmission length
        SAHARA_NAK_INVALID_TX_LENGTH = &HA
        ' Invalid reception length
        SAHARA_NAK_INVALID_RX_LENGTH = &HB
        ' General transmission or reception error
        SAHARA_NAK_GENERAL_TX_RX_ERROR = &HC
        ' Error while transmitting READ_DATA packet
        SAHARA_NAK_READ_DATA_ERROR = &HD
        ' Cannot receive specified number of program headers
        SAHARA_NAK_UNSUPPORTED_NUM_PHDRS = &HE
        ' Invalid data length received for program headers
        SAHARA_NAK_INVALID_PDHR_SIZE = &HF
        ' Multiple shared segments found in ELF image
        SAHARA_NAK_MULTIPLE_SHARED_SEG = &H10
        ' Uninitialized program header location
        SAHARA_NAK_UNINIT_PHDR_LOC = &H11
        ' Invalid destination address
        SAHARA_NAK_INVALID_DEST_ADDR = &H12
        ' Invalid data size receieved in image header
        SAHARA_NAK_INVALID_IMG_HDR_DATA_SIZE = &H13
        ' Invalid ELF header received
        SAHARA_NAK_INVALID_ELF_HDR = &H14
        ' Unknown host error received in HELLO_RESP
        SAHARA_NAK_UNKNOWN_HOST_ERROR = &H15
        ' Timeout while receiving data
        SAHARA_NAK_TIMEOUT_RX = &H16
        ' Timeout while transmitting data
        SAHARA_NAK_TIMEOUT_TX = &H17
        ' Invalid mode received from host
        SAHARA_NAK_INVALID_HOST_MODE = &H18
        ' Invalid memory read access
        SAHARA_NAK_INVALID_MEMORY_READ = &H19
        ' Host cannot handle read data size requested
        SAHARA_NAK_INVALID_DATA_SIZE_REQUEST = &H1A
        ' Memory debug not supported
        SAHARA_NAK_MEMORY_DEBUG_NOT_SUPPORTED = &H1B
        ' Invalid mode switch
        SAHARA_NAK_INVALID_MODE_SWITCH = &H1C
        ' Failed to execute command
        SAHARA_NAK_CMD_EXEC_FAILURE = &H1D
        ' Invalid parameter passed to command execution
        SAHARA_NAK_EXEC_CMD_INVALID_PARAM = &H1E
        ' Unsupported client command received
        SAHARA_NAK_EXEC_CMD_UNSUPPORTED = &H1F
        ' Invalid client command received for data response
        SAHARA_NAK_EXEC_DATA_INVALID_CLIENT_CMD = &H20
        ' Failed to authenticate hash table
        SAHARA_NAK_HASH_TABLE_AUTH_FAILURE = &H21
        ' Failed to verify hash for a given segment of ELF image
        SAHARA_NAK_HASH_VERIFICATION_FAILURE = &H22
        ' Failed to find hash table in ELF image
        SAHARA_NAK_HASH_TABLE_NOT_FOUND = &H23
        ' Place all new error codes above this
        SAHARA_NAK_LAST_CODE
        SAHARA_NAK_MAX_CODE = &H7FFFFFFF ' To ensure 32-bits wide
    End Enum
End Namespace