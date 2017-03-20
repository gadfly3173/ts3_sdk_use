using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IDTMO
{
    using anyID = Int64;

    class ERROR
    {
        public const uint ERROR_ok = 0x0000;
        public const uint ERROR_undefined = 0x0001;
        public const uint ERROR_not_implemented = 0x0002;
        public const uint ERROR_ok_no_update = 0x0003;
        public const uint ERROR_dont_notify = 0x0004;
        public const uint ERROR_lib_time_limit_reached = 0x0005;

        //dunno
        public const uint ERROR_command_not_found = 0x0100;
        public const uint ERROR_unable_to_bind_network_port = 0x0101;
        public const uint ERROR_no_network_port_available = 0x0102;

        //client
        public const uint ERROR_client_invalid_id = 0x0200;
        public const uint ERROR_client_nickname_inuse = 0x0201;
        public const uint ERROR_client_protocol_limit_reached = 0x0203;
        public const uint ERROR_client_invalid_type = 0x0204;
        public const uint ERROR_client_already_subscribed = 0x0205;
        public const uint ERROR_client_not_logged_in = 0x0206;
        public const uint ERROR_client_could_not_validate_identity = 0x0207;
        public const uint ERROR_client_version_outdated = 0x020a;
        public const uint ERROR_client_is_flooding = 0x020c;
        public const uint ERROR_client_hacked = 0x020d;
        public const uint ERROR_client_cannot_verify_now = 0x020e;
        public const uint ERROR_client_login_not_permitted = 0x020f;
        public const uint ERROR_client_not_subscribed = 0x0210;

        //channel
        public const uint ERROR_channel_invalid_id = 0x0300;
        public const uint ERROR_channel_protocol_limit_reached = 0x0301;
        public const uint ERROR_channel_already_in = 0x0302;
        public const uint ERROR_channel_name_inuse = 0x0303;
        public const uint ERROR_channel_not_empty = 0x0304;
        public const uint ERROR_channel_can_not_delete_default = 0x0305;
        public const uint ERROR_channel_default_require_permanent = 0x0306;
        public const uint ERROR_channel_invalid_flags = 0x0307;
        public const uint ERROR_channel_parent_not_permanent = 0x0308;
        public const uint ERROR_channel_maxclients_reached = 0x0309;
        public const uint ERROR_channel_maxfamily_reached = 0x030a;
        public const uint ERROR_channel_invalid_order = 0x030b;
        public const uint ERROR_channel_no_filetransfer_supported = 0x030c;
        public const uint ERROR_channel_invalid_password = 0x030d;
        public const uint ERROR_channel_invalid_security_hash = 0x030f; //note 0x030e is defined in public_rare_errors;

        //server
        public const uint ERROR_server_invalid_id = 0x0400;
        public const uint ERROR_server_running = 0x0401;
        public const uint ERROR_server_is_shutting_down = 0x0402;
        public const uint ERROR_server_maxclients_reached = 0x0403;
        public const uint ERROR_server_invalid_password = 0x0404;
        public const uint ERROR_server_is_virtual = 0x0407;
        public const uint ERROR_server_is_not_running = 0x0409;
        public const uint ERROR_server_is_booting = 0x040a;
        public const uint ERROR_server_status_invalid = 0x040b;
        public const uint ERROR_server_version_outdated = 0x040d;
        public const uint ERROR_server_duplicate_running = 0x040e;

        //parameter
        public const uint ERROR_parameter_quote = 0x0600;
        public const uint ERROR_parameter_invalid_count = 0x0601;
        public const uint ERROR_parameter_invalid = 0x0602;
        public const uint ERROR_parameter_not_found = 0x0603;
        public const uint ERROR_parameter_convert = 0x0604;
        public const uint ERROR_parameter_invalid_size = 0x0605;
        public const uint ERROR_parameter_missing = 0x0606;
        public const uint ERROR_parameter_checksum = 0x0607;

        //unsorted, need further investigation
        public const uint ERROR_vs_critical = 0x0700;
        public const uint ERROR_connection_lost = 0x0701;
        public const uint ERROR_not_connected = 0x0702;
        public const uint ERROR_no_cached_connection_info = 0x0703;
        public const uint ERROR_currently_not_possible = 0x0704;
        public const uint ERROR_failed_connection_initialisation = 0x0705;
        public const uint ERROR_could_not_resolve_hostname = 0x0706;
        public const uint ERROR_invalid_server_connection_handler_id = 0x0707;
        public const uint ERROR_could_not_initialise_input_manager = 0x0708;
        public const uint ERROR_clientlibrary_not_initialised = 0x0709;
        public const uint ERROR_serverlibrary_not_initialised = 0x070a;
        public const uint ERROR_whisper_too_many_targets = 0x070b;
        public const uint ERROR_whisper_no_targets = 0x070c;

        //file transfer
        public const uint ERROR_file_invalid_name = 0x0800;
        public const uint ERROR_file_invalid_permissions = 0x0801;
        public const uint ERROR_file_already_exists = 0x0802;
        public const uint ERROR_file_not_found = 0x0803;
        public const uint ERROR_file_io_error = 0x0804;
        public const uint ERROR_file_invalid_transfer_id = 0x0805;
        public const uint ERROR_file_invalid_path = 0x0806;
        public const uint ERROR_file_no_files_available = 0x0807;
        public const uint ERROR_file_overwrite_excludes_resume = 0x0808;
        public const uint ERROR_file_invalid_size = 0x0809;
        public const uint ERROR_file_already_in_use = 0x080a;
        public const uint ERROR_file_could_not_open_connection = 0x080b;
        public const uint ERROR_file_no_space_left_on_device = 0x080c;
        public const uint ERROR_file_exceeds_file_system_maximum_size = 0x080d;
        public const uint ERROR_file_transfer_connection_timeout = 0x080e;
        public const uint ERROR_file_connection_lost = 0x080f;
        public const uint ERROR_file_exceeds_supplied_size = 0x0810;
        public const uint ERROR_file_transfer_complete = 0x0811;
        public const uint ERROR_file_transfer_canceled = 0x0812;
        public const uint ERROR_file_transfer_interrupted = 0x0813;
        public const uint ERROR_file_transfer_server_quota_exceeded = 0x0814;
        public const uint ERROR_file_transfer_client_quota_exceeded = 0x0815;
        public const uint ERROR_file_transfer_reset = 0x0816;
        public const uint ERROR_file_transfer_limit_reached = 0x0817;

        //sound
        public const uint ERROR_sound_preprocessor_disabled = 0x0900;
        public const uint ERROR_sound_internal_preprocessor = 0x0901;
        public const uint ERROR_sound_internal_encoder = 0x0902;
        public const uint ERROR_sound_internal_playback = 0x0903;
        public const uint ERROR_sound_no_capture_device_available = 0x0904;
        public const uint ERROR_sound_no_playback_device_available = 0x0905;
        public const uint ERROR_sound_could_not_open_capture_device = 0x0906;
        public const uint ERROR_sound_could_not_open_playback_device = 0x0907;
        public const uint ERROR_sound_handler_has_device = 0x0908;
        public const uint ERROR_sound_invalid_capture_device = 0x0909;
        public const uint ERROR_sound_invalid_playback_device = 0x090a;
        public const uint ERROR_sound_invalid_wave = 0x090b;
        public const uint ERROR_sound_unsupported_wave = 0x090c;
        public const uint ERROR_sound_open_wave = 0x090d;
        public const uint ERROR_sound_internal_capture = 0x090e;
        public const uint ERROR_sound_device_in_use = 0x090f;
        public const uint ERROR_sound_device_already_registerred = 0x0910;
        public const uint ERROR_sound_unknown_device = 0x0911;
        public const uint ERROR_sound_unsupported_frequency = 0x0912;
        public const uint ERROR_sound_invalid_channel_count = 0x0913;
        public const uint ERROR_sound_read_wave = 0x0914;
        public const uint ERROR_sound_need_more_data = 0x0915; //for internal purposes only
        public const uint ERROR_sound_device_busy = 0x0916; //for internal purposes only
        public const uint ERROR_sound_no_data = 0x0917;
        public const uint ERROR_sound_channel_mask_mismatch = 0x0918;


        //permissions
        public const uint ERROR_permissions_client_insufficient = 0x0a08;
        public const uint ERROR_permissions = 0x0a0c;

        //accounting
        public const uint ERROR_accounting_virtualserver_limit_reached = 0x0b00;
        public const uint ERROR_accounting_slot_limit_reached = 0x0b01;
        public const uint ERROR_accounting_license_file_not_found = 0x0b02;
        public const uint ERROR_accounting_license_date_not_ok = 0x0b03;
        public const uint ERROR_accounting_unable_to_connect_to_server = 0x0b04;
        public const uint ERROR_accounting_unknown_error = 0x0b05;
        public const uint ERROR_accounting_server_error = 0x0b06;
        public const uint ERROR_accounting_instance_limit_reached = 0x0b07;
        public const uint ERROR_accounting_instance_check_error = 0x0b08;
        public const uint ERROR_accounting_license_file_invalid = 0x0b09;
        public const uint ERROR_accounting_running_elsewhere = 0x0b0a;
        public const uint ERROR_accounting_instance_duplicated = 0x0b0b;
        public const uint ERROR_accounting_already_started = 0x0b0c;
        public const uint ERROR_accounting_not_started = 0x0b0d;
        public const uint ERROR_accounting_to_many_starts = 0x0b0e;

        //provisioning server
        public const uint ERROR_provisioning_invalid_password = 0x1100;
        public const uint ERROR_provisioning_invalid_request = 0x1101;
        public const uint ERROR_provisioning_no_slots_available = 0x1102;
        public const uint ERROR_provisioning_pool_missing = 0x1103;
        public const uint ERROR_provisioning_pool_unknown = 0x1104;
        public const uint ERROR_provisioning_unknown_ip_location = 0x1105;
        public const uint ERROR_provisioning_internal_tries_exceeded = 0x1106;
        public const uint ERROR_provisioning_too_many_slots_requested = 0x1107;
        public const uint ERROR_provisioning_too_many_reserved = 0x1108;
        public const uint ERROR_provisioning_could_not_connect = 0x1109;
        public const uint ERROR_provisioning_auth_server_not_connected = 0x1110;
        public const uint ERROR_provisioning_auth_data_too_large = 0x1111;
        public const uint ERROR_provisioning_already_initialized = 0x1112;
        public const uint ERROR_provisioning_not_initialized = 0x1113;
        public const uint ERROR_provisioning_connecting = 0x1114;
        public const uint ERROR_provisioning_already_connected = 0x1115;
        public const uint ERROR_provisioning_not_connected = 0x1116;
        public const uint ERROR_provisioning_io_error = 0x1117;
        public const uint ERROR_provisioning_invalid_timeout = 0x1118;
        public const uint ERROR_provisioning_ts3server_not_found = 0x1119;
        public const uint ERROR_provisioning_no_permission = 0x111A;
    }
    class Logs
    {
        public enum LogTypes
        {
            LogType_NONE = 0x0000,
            LogType_FILE = 0x0001,
            LogType_CONSOLE = 0x0002,
            LogType_USERLOGGING = 0x0004,
            LogType_NO_NETLOGGING = 0x0008,
            LogType_DATABASE = 0x0010,
        };
        public enum LogLevel
        {
            LogLevel_CRITICAL = 0, //these messages stop the program
            LogLevel_ERROR,        //everything that is really bad, but not so bad we need to shut down
            LogLevel_WARNING,      //everything that *might* be bad
            LogLevel_DEBUG,        //output that might help find a problem
            LogLevel_INFO,         //informational output, like "starting database version x.y.z"
            LogLevel_DEVEL         //developer only output (will not be displayed in release mode)
        };
    }
    class DEF
    {
        public const string NOTOPIC = "NoCallSign";
        public enum TalkStatus : int
        {
            STATUS_NOT_TALKING = 0,
            STATUS_TALKING = 1,
            STATUS_TALKING_WHILE_DISABLED = 2,
        }

        public enum CodecType : int
        {
            CODEC_SPEEX_NARROWBAND = 0, //mono, 16bit, 8kHz, bitrate dependent on the quality setting
            CODEC_SPEEX_WIDEBAND, //mono, 16bit, 16kHz, bitrate dependent on the quality setting
            CODEC_SPEEX_ULTRAWIDEBAND, //mono, 16bit, 32kHz, bitrate dependent on the quality setting
            CODEC_CELT_MONO, //mono, 16bit, 48kHz, bitrate dependent on the quality setting
            CODEC_OPUS_VOICE, //mono, 16bit, 48khz, bitrate dependent on the quality setting, optimized for voice
            CODEC_OPUS_MUSIC, //stereo, 16bit, 48khz, bitrate dependent on the quality setting, optimized for music
        }

        public enum CodecEncryptionMode : int
        {
            CODEC_ENCRYPTION_PER_CHANNEL = 0,
            CODEC_ENCRYPTION_FORCED_OFF,
            CODEC_ENCRYPTION_FORCED_ON,
        }

        public enum TextMessageTargetMode : int
        {
            TextMessageTarget_CLIENT = 1,
            TextMessageTarget_CHANNEL,
            TextMessageTarget_SERVER,
            TextMessageTarget_MAX
        }

        public enum MuteInputStatus : int
        {
            MUTEINPUT_NONE = 0,
            MUTEINPUT_MUTED,
        }

        public enum MuteOutputStatus : int
        {
            MUTEOUTPUT_NONE = 0,
            MUTEOUTPUT_MUTED,
        }

        public enum HardwareInputStatus : int
        {
            HARDWAREINPUT_DISABLED = 0,
            HARDWAREINPUT_ENABLED,
        }

        public enum HardwareOutputStatus : int
        {
            HARDWAREOUTPUT_DISABLED = 0,
            HARDWAREOUTPUT_ENABLED,
        }

        public enum InputDeactivationStatus : int
        {
            INPUT_ACTIVE = 0,
            INPUT_DEACTIVATED = 1,
        }

        public enum ReasonIdentifier : int
        {
            REASON_NONE = 0, //no reason data
            REASON_MOVED = 1, //{SectionInvoker}
            REASON_SUBSCRIPTION = 2, //no reason data
            REASON_LOST_CONNECTION = 3, //reasonmsg=reason
            REASON_KICK_CHANNEL = 4, //{SectionInvoker} reasonmsg=reason //{SectionInvoker} is only added server->client
            REASON_KICK_SERVER = 5, //{SectionInvoker} reasonmsg=reason //{SectionInvoker} is only added server->client
            REASON_KICK_SERVER_BAN = 6, //{SectionInvoker} reasonmsg=reason bantime=time //{SectionInvoker} is only added server->client
            REASON_SERVERSTOP = 7, //reasonmsg=reason
            REASON_CLIENTDISCONNECT = 8, //reasonmsg=reason
            REASON_CHANNELUPDATE = 9, //no reason data
            REASON_CHANNELEDIT = 10, //{SectionInvoker}
            REASON_CLIENTDISCONNECT_SERVER_SHUTDOWN = 11, //reasonmsg=reason
        }

        public enum ChannelProperties : int
        {
            CHANNEL_NAME = 0, //Available for all channels that are "in view", always up-to-date
            /// <summary>
            /// 频道主题
            /// </summary>
            CHANNEL_TOPIC, //Available for all channels that are "in view", always up-to-date
            /// <summary>
            /// 频道描述
            /// </summary>
            CHANNEL_DESCRIPTION, //Must be requested (=> requestChannelDescription)
            CHANNEL_PASSWORD, //not available client side
            CHANNEL_CODEC, //Available for all channels that are "in view", always up-to-date
            CHANNEL_CODEC_QUALITY, //Available for all channels that are "in view", always up-to-date
            CHANNEL_MAXCLIENTS, //Available for all channels that are "in view", always up-to-date
            CHANNEL_MAXFAMILYCLIENTS, //Available for all channels that are "in view", always up-to-date
            CHANNEL_ORDER, //Available for all channels that are "in view", always up-to-date
            CHANNEL_FLAG_PERMANENT, //Available for all channels that are "in view", always up-to-date
            CHANNEL_FLAG_SEMI_PERMANENT, //Available for all channels that are "in view", always up-to-date
            CHANNEL_FLAG_DEFAULT, //Available for all channels that are "in view", always up-to-date
            CHANNEL_FLAG_PASSWORD, //Available for all channels that are "in view", always up-to-date
            CHANNEL_CODEC_LATENCY_FACTOR, //Available for all channels that are "in view", always up-to-date
            CHANNEL_CODEC_IS_UNENCRYPTED, //Available for all channels that are "in view", always up-to-date
            CHANNEL_SECURITY_SALT, //Not available client side, not used in teamspeak, only SDK. Sets the options+salt for security hash.
            CHANNEL_DELETE_DELAY, //How many seconds to wait before deleting this channel
            CHANNEL_ENDMARKER,
        }

        public enum ClientProperties : int
        {
            CLIENT_UNIQUE_IDENTIFIER = 0, //automatically up-to-date for any client "in view", can be used to identify this particular client installation
            CLIENT_NICKNAME, //automatically up-to-date for any client "in view"
            CLIENT_VERSION, //for other clients than ourself, this needs to be requested (=> requestClientVariables)
            CLIENT_PLATFORM, //for other clients than ourself, this needs to be requested (=> requestClientVariables)
            CLIENT_FLAG_TALKING, //automatically up-to-date for any client that can be heard (in room / whisper)
            CLIENT_INPUT_MUTED, //automatically up-to-date for any client "in view", this clients microphone mute status
            CLIENT_OUTPUT_MUTED, //automatically up-to-date for any client "in view", this clients headphones/speakers/mic combined mute status
            CLIENT_OUTPUTONLY_MUTED, //automatically up-to-date for any client "in view", this clients headphones/speakers only mute status
            CLIENT_INPUT_HARDWARE, //automatically up-to-date for any client "in view", this clients microphone hardware status (is the capture device opened?)
            CLIENT_OUTPUT_HARDWARE, //automatically up-to-date for any client "in view", this clients headphone/speakers hardware status (is the playback device opened?)
            CLIENT_INPUT_DEACTIVATED, //only usable for ourself, not propagated to the network
            CLIENT_IDLE_TIME, //internal use
            CLIENT_DEFAULT_CHANNEL, //only usable for ourself, the default channel we used to connect on our last connection attempt
            CLIENT_DEFAULT_CHANNEL_PASSWORD, //internal use
            CLIENT_SERVER_PASSWORD, //internal use
            CLIENT_META_DATA, //automatically up-to-date for any client "in view", not used by TeamSpeak, free storage for sdk users
            CLIENT_IS_MUTED, //only make sense on the client side locally, "1" if this client is currently muted by us, "0" if he is not
            CLIENT_IS_RECORDING, //automatically up-to-date for any client "in view"
            CLIENT_VOLUME_MODIFICATOR, //internal use
            CLIENT_VERSION_SIGN, //sign
            CLIENT_SECURITY_HASH, //SDK use, not used by teamspeak. Hash is provided by an outside source. A channel will use the security salt + other client data to calculate a hash, which must be the same as the one provided here.
            CLIENT_ENDMARKER,
        }

        public enum VirtualServerProperties : int
        {
            VIRTUALSERVER_UNIQUE_IDENTIFIER = 0, //available when connected, can be used to identify this particular server installation
            VIRTUALSERVER_NAME, //available and always up-to-date when connected
            VIRTUALSERVER_WELCOMEMESSAGE, //available when connected, (=> requestServerVariables)
            VIRTUALSERVER_PLATFORM, //available when connected
            VIRTUALSERVER_VERSION, //available when connected
            VIRTUALSERVER_MAXCLIENTS, //only available on request (=> requestServerVariables), stores the maximum number of clients that may currently join the server
            VIRTUALSERVER_PASSWORD, //not available to clients, the server password
            VIRTUALSERVER_CLIENTS_ONLINE, //only available on request (=> requestServerVariables),
            VIRTUALSERVER_CHANNELS_ONLINE, //only available on request (=> requestServerVariables),
            VIRTUALSERVER_CREATED, //available when connected, stores the time when the server was created
            VIRTUALSERVER_UPTIME, //only available on request (=> requestServerVariables), the time since the server was started
            VIRTUALSERVER_CODEC_ENCRYPTION_MODE, //available and always up-to-date when connected
            VIRTUALSERVER_ENDMARKER,
        }

        public enum ConnectionProperties : int
        {
            CONNECTION_PING = 0, //average latency for a round trip through and back this connection
            CONNECTION_PING_DEVIATION, //standard deviation of the above average latency
            CONNECTION_CONNECTED_TIME, //how long the connection exists already
            CONNECTION_IDLE_TIME, //how long since the last action of this client
            CONNECTION_CLIENT_IP, //IP of this client (as seen from the server side)
            CONNECTION_CLIENT_PORT, //Port of this client (as seen from the server side)
            CONNECTION_SERVER_IP, //IP of the server (seen from the client side) - only available on yourself, not for remote clients, not available server side
            CONNECTION_SERVER_PORT, //Port of the server (seen from the client side) - only available on yourself, not for remote clients, not available server side
            CONNECTION_PACKETS_SENT_SPEECH, //how many Speech packets were sent through this connection
            CONNECTION_PACKETS_SENT_KEEPALIVE,
            CONNECTION_PACKETS_SENT_CONTROL,
            CONNECTION_PACKETS_SENT_TOTAL, //how many packets were sent totally (this is PACKETS_SENT_SPEECH + PACKETS_SENT_KEEPALIVE + PACKETS_SENT_CONTROL)
            CONNECTION_BYTES_SENT_SPEECH,
            CONNECTION_BYTES_SENT_KEEPALIVE,
            CONNECTION_BYTES_SENT_CONTROL,
            CONNECTION_BYTES_SENT_TOTAL,
            CONNECTION_PACKETS_RECEIVED_SPEECH,
            CONNECTION_PACKETS_RECEIVED_KEEPALIVE,
            CONNECTION_PACKETS_RECEIVED_CONTROL,
            CONNECTION_PACKETS_RECEIVED_TOTAL,
            CONNECTION_BYTES_RECEIVED_SPEECH,
            CONNECTION_BYTES_RECEIVED_KEEPALIVE,
            CONNECTION_BYTES_RECEIVED_CONTROL,
            CONNECTION_BYTES_RECEIVED_TOTAL,
            CONNECTION_PACKETLOSS_SPEECH,
            CONNECTION_PACKETLOSS_KEEPALIVE,
            CONNECTION_PACKETLOSS_CONTROL,
            CONNECTION_PACKETLOSS_TOTAL, //the probability with which a packet round trip failed because a packet was lost
            CONNECTION_SERVER2CLIENT_PACKETLOSS_SPEECH, //the probability with which a speech packet failed from the server to the client
            CONNECTION_SERVER2CLIENT_PACKETLOSS_KEEPALIVE,
            CONNECTION_SERVER2CLIENT_PACKETLOSS_CONTROL,
            CONNECTION_SERVER2CLIENT_PACKETLOSS_TOTAL,
            CONNECTION_CLIENT2SERVER_PACKETLOSS_SPEECH,
            CONNECTION_CLIENT2SERVER_PACKETLOSS_KEEPALIVE,
            CONNECTION_CLIENT2SERVER_PACKETLOSS_CONTROL,
            CONNECTION_CLIENT2SERVER_PACKETLOSS_TOTAL,
            CONNECTION_BANDWIDTH_SENT_LAST_SECOND_SPEECH, //howmany bytes of speech packets we sent during the last second
            CONNECTION_BANDWIDTH_SENT_LAST_SECOND_KEEPALIVE,
            CONNECTION_BANDWIDTH_SENT_LAST_SECOND_CONTROL,
            CONNECTION_BANDWIDTH_SENT_LAST_SECOND_TOTAL,
            CONNECTION_BANDWIDTH_SENT_LAST_MINUTE_SPEECH, //howmany bytes/s of speech packets we sent in average during the last minute
            CONNECTION_BANDWIDTH_SENT_LAST_MINUTE_KEEPALIVE,
            CONNECTION_BANDWIDTH_SENT_LAST_MINUTE_CONTROL,
            CONNECTION_BANDWIDTH_SENT_LAST_MINUTE_TOTAL,
            CONNECTION_BANDWIDTH_RECEIVED_LAST_SECOND_SPEECH,
            CONNECTION_BANDWIDTH_RECEIVED_LAST_SECOND_KEEPALIVE,
            CONNECTION_BANDWIDTH_RECEIVED_LAST_SECOND_CONTROL,
            CONNECTION_BANDWIDTH_RECEIVED_LAST_SECOND_TOTAL,
            CONNECTION_BANDWIDTH_RECEIVED_LAST_MINUTE_SPEECH,
            CONNECTION_BANDWIDTH_RECEIVED_LAST_MINUTE_KEEPALIVE,
            CONNECTION_BANDWIDTH_RECEIVED_LAST_MINUTE_CONTROL,
            CONNECTION_BANDWIDTH_RECEIVED_LAST_MINUTE_TOTAL,
            CONNECTION_ENDMARKER,
        }

        public class TS3_VECTOR
        {
            public float x; // X co-ordinate in 3D space. 
            public float y; // Y co-ordinate in 3D space. 
            public float z; // Z co-ordinate in 3D space. 
        }

        public enum GroupWhisperType : int
        {
            GROUPWHISPERTYPE_SERVERGROUP = 0,
            GROUPWHISPERTYPE_CHANNELGROUP = 1,
            GROUPWHISPERTYPE_CHANNELCOMMANDER = 2,
            GROUPWHISPERTYPE_ALLCLIENTS = 3,
            GROUPWHISPERTYPE_ENDMARKER,
        }

        public enum GroupWhisperTargetMode : int
        {
            GROUPWHISPERTARGETMODE_ALL = 0,
            GROUPWHISPERTARGETMODE_CURRENTCHANNEL = 1,
            GROUPWHISPERTARGETMODE_PARENTCHANNEL = 2,
            GROUPWHISPERTARGETMODE_ALLPARENTCHANNELS = 3,
            GROUPWHISPERTARGETMODE_CHANNELFAMILY = 4,
            GROUPWHISPERTARGETMODE_ANCESTORCHANNELFAMILY = 5,
            GROUPWHISPERTARGETMODE_SUBCHANNELS = 6,
            GROUPWHISPERTARGETMODE_ENDMARKER,
        }

        public enum MonoSoundDestination : int
        {
            MONO_SOUND_DESTINATION_ALL = 0, // Send mono sound to all available speakers 
            MONO_SOUND_DESTINATION_FRONT_CENTER = 1, // Send mono sound to front center speaker if available 
            MONO_SOUND_DESTINATION_FRONT_LEFT_AND_RIGHT = 2 // Send mono sound to front left/right speakers if available 
        }

        public enum SecuritySaltOptions : int
        {
            SECURITY_SALT_CHECK_NICKNAME = 1, // put nickname into security hash 
            SECURITY_SALT_CHECK_META_DATA = 2 // put (game)meta data into security hash 
        }

        //this enum is used to disable client commands on the server
        public enum ClientCommand : int
        {
            CLIENT_COMMAND_requestConnectionInfo = 0,
            CLIENT_COMMAND_requestClientMove = 1,
            CLIENT_COMMAND_requestXXMuteClients = 2,
            CLIENT_COMMAND_requestClientKickFromXXX = 3,
            CLIENT_COMMAND_flushChannelCreation = 4,
            CLIENT_COMMAND_flushChannelUpdates = 5,
            CLIENT_COMMAND_requestChannelMove = 6,
            CLIENT_COMMAND_requestChannelDelete = 7,
            CLIENT_COMMAND_requestChannelDescription = 8,
            CLIENT_COMMAND_requestChannelXXSubscribeXXX = 9,
            CLIENT_COMMAND_requestServerConnectionInfo = 10,
            CLIENT_COMMAND_requestSendXXXTextMsg = 11,
            CLIENT_COMMAND_filetransfers = 12,
            CLIENT_COMMAND_ENDMARKER
        }

        // Access Control List
        public enum ACLType : int
        {
            ACL_NONE = 0,
            ACL_WHITE_LIST = 1,
            ACL_BLACK_LIST = 2
        }

        // file transfer actions
        public enum FTAction : int
        {
            FT_INIT_SERVER = 0,
            FT_INIT_CHANNEL = 1,
            FT_UPLOAD = 2,
            FT_DOWNLOAD = 3,
            FT_DELETE = 4,
            FT_CREATEDIR = 5,
            FT_RENAME = 6,
            FT_FILELIST = 7,
            FT_FILEINFO = 8
        }

        // file transfer status 
        public enum FileTransferState : int
        {
            FILETRANSFER_INITIALISING = 0,
            FILETRANSFER_ACTIVE,
            FILETRANSFER_FINISHED,
        }
        public enum AnonymousEnum : int
        {
            FileListType_Directory = 0,
            FileListType_File,
        }
        public class VariablesExportItem
        {
            public byte itemIsValid; // This item has valid values. ignore this item if 0 
            public byte proposedIsSet; // The value in proposed is set. if 0 ignore proposed 
            public string current; // current value (stored in memory) 
            public string proposed; // New value to change to (const, so no updates please) 
        }

        public class VariablesExport
        {
            //public VariablesExportItem[] items = new VariablesExportItem[DefineConstantsTeamlog: Logs.MAX_VARIABLES_EXPORT_COUNT];
        }

        public class ClientMiniExport
        {
            public ushort ID;
            public uint channel;
            public string ident;
            public string nickname;
        }


        public class FileTransferCallbackExport
        {
#if anyID_AlternateDefinition1
	public ushort clientID;
#elif anyID_AlternateDefinition2
            public uint16_t clientID = new uint16_t();
#endif
#if anyID_AlternateDefinition1
	public ushort transferID;
#elif anyID_AlternateDefinition2
            public uint16_t transferID = new uint16_t();
#endif
#if anyID_AlternateDefinition1
	public ushort remoteTransferID;
#elif anyID_AlternateDefinition2
            public uint16_t remoteTransferID = new uint16_t();
#endif
            public uint status;
            public string statusMessage;
#if uint64_AlternateDefinition1
	public uint @long remotefileSize;
#elif uint64_AlternateDefinition2
            public uint64_t remotefileSize = new uint64_t();
#endif
#if uint64_AlternateDefinition1
	public uint @long bytes;
#elif uint64_AlternateDefinition2
            public uint64_t bytes = new uint64_t();
#endif
            public int isSender;
        }
        public const int TS3_MAX_SIZE_CHANNEL_NAME = 40;
        public const int TS3_MAX_SIZE_VIRTUALSERVER_NAME = 64;
        public const int TS3_MAX_SIZE_CLIENT_NICKNAME = 64;
        public const int TS3_MIN_SIZE_CLIENT_NICKNAME = 3;
        public const int TS3_MAX_SIZE_REASON_MESSAGE = 80;
        public const int TS3_MAX_SIZE_TEXTMESSAGE = 1024;
        public const int TS3_MAX_SIZE_CHANNEL_TOPIC = 255;
        public const int TS3_MAX_SIZE_CHANNEL_DESCRIPTION = 8192;
        public const int TS3_MAX_SIZE_VIRTUALSERVER_WELCOMEMESSAGE = 1024;
        public const int TS3_MIN_SECONDS_CLIENTID_REUSE = 300;
        public const int MAX_VARIABLES_EXPORT_COUNT = 64;
        public const int SPEAKER_FRONT_LEFT = 0x1;
        public const int SPEAKER_FRONT_RIGHT = 0x2;
        public const int SPEAKER_FRONT_CENTER = 0x4;
        public const int SPEAKER_LOW_FREQUENCY = 0x8;
        public const int SPEAKER_BACK_LEFT = 0x10;
        public const int SPEAKER_BACK_RIGHT = 0x20;
        public const int SPEAKER_FRONT_LEFT_OF_CENTER = 0x40;
        public const int SPEAKER_FRONT_RIGHT_OF_CENTER = 0x80;
        public const int SPEAKER_BACK_CENTER = 0x100;
        public const int SPEAKER_SIDE_LEFT = 0x200;
        public const int SPEAKER_SIDE_RIGHT = 0x400;
        public const int SPEAKER_TOP_CENTER = 0x800;
        public const int SPEAKER_TOP_FRONT_LEFT = 0x1000;
        public const int SPEAKER_TOP_FRONT_CENTER = 0x2000;
        public const int SPEAKER_TOP_FRONT_RIGHT = 0x4000;
        public const int SPEAKER_TOP_BACK_LEFT = 0x8000;
        public const int SPEAKER_TOP_BACK_CENTER = 0x10000;
        public const int SPEAKER_TOP_BACK_RIGHT = 0x20000;
        public const int SPEAKER_HEADPHONES_LEFT = 0x10000000;
        public const int SPEAKER_HEADPHONES_RIGHT = 0x20000000;
        public const int SPEAKER_MONO = 0x40000000;

    }
    class clientp
    {
        public enum Visibility
        {
            ENTER_VISIBILITY = 0,
            RETAIN_VISIBILITY,
            LEAVE_VISIBILITY
        };

        public enum ConnectStatus
        {
            STATUS_DISCONNECTED = 0,       //There is no activity to the server, this is the default value
            STATUS_CONNECTING,             //We are trying to connect, we haven't got a clientID yet, we haven't been accepted by the server
            STATUS_CONNECTED,              //The server has accepted us, we can talk and hear and we got a clientID, but we don't have the channels and clients yet, we can get server infos (welcome msg etc.)
            STATUS_CONNECTION_ESTABLISHING,//we are CONNECTED and we are visible
            STATUS_CONNECTION_ESTABLISHED, //we are CONNECTED and we have the client and channels available
        };
    }
}
