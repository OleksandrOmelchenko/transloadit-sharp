namespace Transloadit.Constants
{
    /// <summary>
    /// Contains response codes returned by Transloadit API.
    /// </summary>
    public static class ResponseCodes
    {
        /// <summary>
        /// The Assembly was canceled.
        /// </summary>
        public const string AssemblyCanceled = "ASSEMBLY_CANCELED";

        /// <summary>
        /// The Assembly was completed successfully.
        /// </summary>
        public const string AssemblyCompleted = "ASSEMBLY_COMPLETED";

        /// <summary>
        /// The Assembly is currently being executed.
        /// </summary>
        public const string AssemblyExecuting = "ASSEMBLY_EXECUTING";

        /// <summary>
        /// The Assembly is being replayed.
        /// </summary>
        public const string AssemblyReplaying = "ASSEMBLY_REPLAYING";

        /// <summary>
        /// The Assembly is still in the process of being uploaded.
        /// </summary>
        public const string AssemblyUploading = "ASSEMBLY_UPLOADING";

        /// <summary>
        /// The upload connection was closed or timed out before receiving all data.
        /// </summary>
        public const string RequestAborted = "REQUEST_ABORTED";

        /// <summary>
        /// Number of active Assemblies fetched.
        /// </summary>
        public const string ActiveAssembliesFetched = "ACTIVE_ASSEMBLIES_FETCHED";

        /// <summary>
        /// You require admin permissions to do this.
        /// </summary>
        public const string AdminPermissionsRequired = "ADMIN_PERMISSIONS_REQUIRED";

        /// <summary>
        /// The Assemblies have been updated.
        /// </summary>
        public const string AssembliesUpdated = "ASSEMBLIES_UPDATED";

        /// <summary>
        /// You are not allowed to access this Assembly because it is not yours.
        /// </summary>
        public const string AssemblyAccountMismatch = "ASSEMBLY_ACCOUNT_MISMATCH";

        /// <summary>
        /// The Assembly cannot be replayed.
        /// </summary>
        public const string AssemblyCannotBeReplayed = "ASSEMBLY_CANNOT_BE_REPLAYED";

        /// <summary>
        /// The Assembly could not be created.
        /// </summary>
        public const string AssemblyCouldNotBeCreated = "ASSEMBLY_COULD_NOT_BE_CREATED";

        /// <summary>
        /// The process managing this Assembly crashed and could not be restored.
        /// </summary>
        public const string AssemblyCrashed = "ASSEMBLY_CRASHED";

        /// <summary>
        /// Your Assembly uses one or more disallowed Robots.
        /// </summary>
        public const string AssemblyDisallowedRobotsUsed = "ASSEMBLY_DISALLOWED_ROBOTS_USED";

        /// <summary>
        /// Your Assembly {steps: ...} as export const parameter is empty.
        /// </summary>
        public const string AssemblyEmptySteps = "ASSEMBLY_EMPTY_STEPS";

        /// <summary>
        /// For this Assembly, retrieving execution progress has not been enabled.
        /// </summary>
        public const string AssemblyExecutionProgressNotEnabled = "ASSEMBLY_EXECUTION_PROGRESS_NOT_ENABLED";

        /// <summary>
        /// The Assembly expired.
        /// </summary>
        public const string AssemblyExpired = "ASSEMBLY_EXPIRED";

        /// <summary>
        /// The Assembly accepted the added file.
        /// </summary>
        public const string AssemblyFileAccepted = "ASSEMBLY_FILE_ACCEPTED";

        /// <summary>
        /// A place for this file must be reserved before adding it.
        /// </summary>
        public const string AssemblyFileNotReserved = "ASSEMBLY_FILE_NOT_RESERVED";

        /// <summary>
        /// The Assembly reserved a space for this file.
        /// </summary>
        public const string AssemblyFileReserved = "ASSEMBLY_FILE_RESERVED";

        /// <summary>
        /// Your Assembly appears to be infinite, the "use" parameters form a loop.
        /// </summary>
        public const string AssemblyInfinite = "ASSEMBLY_INFINITE";

        /// <summary>
        /// The Assembly had a malformed notify_url. They must be strings.
        /// </summary>
        public const string AssemblyInvalidNotifyUrl = "ASSEMBLY_INVALID_NOTIFY_URL";

        /// <summary>
        /// Your 'num_expected_upload_files' parameter value is invalid. It must be a number greater than or equal zero.
        /// </summary>
        public const string AssemblyInvalidNumExpectedUploadFilesParam = "ASSEMBLY_INVALID_NUM_EXPECTED_UPLOAD_FILES_PARAM";

        /// <summary>
        /// Your Assembly {steps: ...} as export const is a non-object value.
        /// </summary>
        public const string AssemblyInvalidSteps = "ASSEMBLY_INVALID_STEPS";

        /// <summary>
        /// There was a problem enqueuing a job for your Assembly. Please reach out to support.
        /// </summary>
        public const string AssemblyJobEnqueueError = "ASSEMBLY_JOB_ENQUEUE_ERROR";

        /// <summary>
        /// Bad parameters
        /// </summary>
        public const string AssemblyListError = "ASSEMBLY_LIST_ERROR";

        /// <summary>
        /// The Assembly memory limit of 8MB was exceeded. Please try to import less files and/or upload a zip file with less files.
        /// </summary>
        public const string AssemblyMemoryLimitExceeded = "ASSEMBLY_MEMORY_LIMIT_EXCEEDED";

        /// <summary>
        /// The Assembly notification was replayed.
        /// </summary>
        public const string AssemblyNotificationReplayed = "ASSEMBLY_NOTIFICATION_REPLAYED";

        /// <summary>
        /// The Assembly notifications could not be listed.
        /// </summary>
        public const string AssemblyNotificationsListError = "ASSEMBLY_NOTIFICATIONS_LIST_ERROR";

        /// <summary>
        /// Bad parameters
        /// </summary>
        public const string AssemblyNotificationListError = "ASSEMBLY_NOTIFICATION_LIST_ERROR";

        /// <summary>
        /// There was a problem saving the Assembly notification. Please get in touch with support.
        /// </summary>
        public const string AssemblyNotificationNotPersisted = "ASSEMBLY_NOTIFICATION_NOT_PERSISTED";

        /// <summary>
        /// The Assembly notification could not be replayed.
        /// </summary>
        public const string AssemblyNotificationNotReplayed = "ASSEMBLY_NOTIFICATION_NOT_REPLAYED";

        /// <summary>
        /// This Assembly is not capable of handling the requested endpoint.
        /// </summary>
        public const string AssemblyNotCapable = "ASSEMBLY_NOT_CAPABLE";

        /// <summary>
        /// The Assembly is not finished yet and thus cannot be replayed yet.
        /// </summary>
        public const string AssemblyNotFinished = "ASSEMBLY_NOT_FINISHED";

        /// <summary>
        /// The Assembly you requested crashed or does not exist.
        /// </summary>
        public const string AssemblyNotFound = "ASSEMBLY_NOT_FOUND";

        /// <summary>
        /// The Assembly could not be replayed
        /// </summary>
        public const string AssemblyNotReplayed = "ASSEMBLY_NOT_REPLAYED";

        /// <summary>
        /// An Assembly must have at least one transcoding or Step.
        /// </summary>
        public const string AssemblyNoChargeableStep = "ASSEMBLY_NO_CHARGEABLE_STEP";

        /// <summary>
        /// The Assembly had not configured any notify_url.
        /// </summary>
        public const string AssemblyNoNotifyUrl = "ASSEMBLY_NO_NOTIFY_URL";

        /// <summary>
        /// Your Assembly does not include a {steps: ...} as export const parameter.
        /// </summary>
        public const string AssemblyNoSteps = "ASSEMBLY_NO_STEPS";

        /// <summary>
        /// The Assembly's upload progress has been updated.
        /// </summary>
        public const string AssemblyProgressUpdated = "ASSEMBLY_PROGRESS_UPDATED";

        /// <summary>
        /// This Assembly must make use of specific robots as per the contract.
        /// </summary>
        public const string AssemblyRobotMissing = "ASSEMBLY_ROBOT_MISSING";

        /// <summary>
        /// This Assembly has already received all expected file uploads.
        /// </summary>
        public const string AssemblySaturated = "ASSEMBLY_SATURATED";

        /// <summary>
        /// since time is missing or incorrect
        /// </summary>
        public const string AssemblyStatsInvalidTime = "ASSEMBLY_STATS_INVALID_TIME";

        /// <summary>
        /// Must provide a specific region, or "all"
        /// </summary>
        public const string AssemblyStatsMissingRegion = "ASSEMBLY_STATS_MISSING_REGION";

        /// <summary>
        /// You are fetching status for the same Assembly too often. Please slow down.
        /// </summary>
        public const string AssemblyStatusFetchingRateLimitReached = "ASSEMBLY_STATUS_FETCHING_RATE_LIMIT_REACHED";

        /// <summary>
        /// The status for the Assembly you requested could not be found.
        /// </summary>
        public const string AssemblyStatusNotFound = "ASSEMBLY_STATUS_NOT_FOUND";

        /// <summary>
        /// There was a problem parsing the status json of the Assembly.
        /// </summary>
        public const string AssemblyStatusParseError = "ASSEMBLY_STATUS_PARSE_ERROR";

        /// <summary>
        /// One of your {steps: ...} as export const parameters is a non-object value.
        /// </summary>
        public const string AssemblyStepInvalid = "ASSEMBLY_STEP_INVALID";

        /// <summary>
        /// One of your step parameters includes an non-string {robot: ...} as export const value.
        /// </summary>
        public const string AssemblyStepInvalidRobot = "ASSEMBLY_STEP_INVALID_ROBOT";

        /// <summary>
        /// One of your step parameters either includes a non-array {use: ...} as export const value or the members of the "use" array are not strings or objects. If they are objects, they must contain a "name" property.
        /// </summary>
        public const string AssemblyStepInvalidUse = "ASSEMBLY_STEP_INVALID_USE";

        /// <summary>
        /// One of your step parameters did not include a {robot: ...} as export const key.
        /// </summary>
        public const string AssemblyStepNoRobot = "ASSEMBLY_STEP_NO_ROBOT";

        /// <summary>
        /// One of your step parameters is referencing an unknown {robot: ...} as const.
        /// </summary>
        public const string AssemblyStepUnknownRobot = "ASSEMBLY_STEP_UNKNOWN_ROBOT";

        /// <summary>
        /// One of your step parameters references an unknown {use: ...} as export const value.
        /// </summary>
        public const string AssemblyStepUnknownUse = "ASSEMBLY_STEP_UNKNOWN_USE";

        /// <summary>
        /// This Assembly must use the UrlTransform feature as per the contract.
        /// </summary>
        public const string AssemblyUrlTransformMissing = "ASSEMBLY_URL_TRANSFORM_MISSING";

        /// <summary>
        /// The given auth expires parameter is in the past.
        /// </summary>
        public const string AuthExpired = "AUTH_EXPIRED";

        /// <summary>
        /// Your auth keys were successfully found.
        /// </summary>
        public const string AuthKeysFound = "AUTH_KEYS_FOUND";

        /// <summary>
        /// Your auth keys could not be found.
        /// </summary>
        public const string AuthKeysNotFound = "AUTH_KEYS_NOT_FOUND";

        /// <summary>
        /// Your Auth Key was successfully created.
        /// </summary>
        public const string AuthKeyCreated = "AUTH_KEY_CREATED";

        /// <summary>
        /// Your Auth Key was successfully deleted.
        /// </summary>
        public const string AuthKeyDeleted = "AUTH_KEY_DELETED";

        /// <summary>
        /// Your Auth Key could not be created.
        /// </summary>
        public const string AuthKeyNotCreated = "AUTH_KEY_NOT_CREATED";

        /// <summary>
        /// Your Auth Key could not be deleted.
        /// </summary>
        public const string AuthKeyNotDeleted = "AUTH_KEY_NOT_DELETED";

        /// <summary>
        /// Your Auth Key could not be updated.
        /// </summary>
        public const string AuthKeyNotUpdated = "AUTH_KEY_NOT_UPDATED";

        /// <summary>
        /// The Auth Key scopes were successfully found.
        /// </summary>
        public const string AuthKeyScopesFound = "AUTH_KEY_SCOPES_FOUND";

        /// <summary>
        /// The Auth Key scopes could not be found.
        /// </summary>
        public const string AuthKeyScopesNotFound = "AUTH_KEY_SCOPES_NOT_FOUND";

        /// <summary>
        /// Your Auth Key was successfully updated.
        /// </summary>
        public const string AuthKeyUpdated = "AUTH_KEY_UPDATED";

        /// <summary>
        /// Your auth secret could not be shown.
        /// </summary>
        public const string AuthSecretNotRetrieved = "AUTH_SECRET_NOT_RETRIEVED";

        /// <summary>
        /// Your auth secret could be retrieved.
        /// </summary>
        public const string AuthSecretRetrieved = "AUTH_SECRET_RETRIEVED";

        /// <summary>
        /// Something is wrong with the pricing record attached to your workspace, please contact support.
        /// </summary>
        public const string BadPricing = "BAD_PRICING";

        /// <summary>
        /// The bill was successfully found.
        /// </summary>
        public const string BillFound = "BILL_FOUND";

        /// <summary>
        /// The bill limit that was configured for this workspace is exceeded this month.
        /// </summary>
        public const string BillLimitExceeded = "BILL_LIMIT_EXCEEDED";

        /// <summary>
        /// Got an error fetching the number of active Assemblies.
        /// </summary>
        public const string CannotFetchActiveAssemblies = "CANNOT_FETCH_ACTIVE_ASSEMBLIES";

        /// <summary>
        /// We recommend URL Transform is only used in combination with a CDN to cache results. Otherwise each hit is transcoded which may ramp up bills fast for popular pages. That's why you should (have your CDN) set the query parameter or header key: 'cdn' with the value: 'required'.
        /// </summary>
        public const string CdnRequired = "CDN_REQUIRED";

        /// <summary>
        /// Unable to validate Basic Auth credentials
        /// </summary>
        public const string CompanionBasicAuthUnset = "COMPANION_BASIC_AUTH_UNSET";

        /// <summary>
        /// Companion credentials request contains invalid data
        /// </summary>
        public const string CompanionCredentialsRequestInvalid = "COMPANION_CREDENTIALS_REQUEST_INVALID";

        /// <summary>
        /// Companion OSS support ping request contains invalid data
        /// </summary>
        public const string CompanionOssSupportPingRequestInvalid = "COMPANION_OSS_SUPPORT_PING_REQUEST_INVALID";

        /// <summary>
        /// Transloadit was unable to download an external file.
        /// </summary>
        public const string FileDownloadError = "FILE_DOWNLOAD_ERROR";

        /// <summary>
        /// There was a problem extracting meta data information from your file.
        /// </summary>
        public const string FileMetaDataError = "FILE_META_DATA_ERROR";

        /// <summary>
        /// The /file/serve Step has no result to serve. Possibly your Instructions do not support the input file type.
        /// </summary>
        public const string FileServeNoResult = "FILE_SERVE_NO_RESULT";

        /// <summary>
        /// Could not get workspace, there was a database error.
        /// </summary>
        public const string GetAccountDbError = "GET_ACCOUNT_DB_ERROR";

        /// <summary>
        /// Could not get workspace, this is an unknown Auth Key.
        /// </summary>
        public const string GetAccountUnknownAuthKey = "GET_ACCOUNT_UNKNOWN_AUTH_KEY";

        /// <summary>
        /// Grafana webhook error
        /// </summary>
        public const string GrafanaWebhookError = "GRAFANA_WEBHOOK_ERROR";

        /// <summary>
        /// Grafana webhook write error
        /// </summary>
        public const string GrafanaWebhookWriteError = "GRAFANA_WEBHOOK_WRITE_ERROR";

        /// <summary>
        /// Transloadit was unable to import a file.
        /// </summary>
        public const string ImportFileError = "IMPORT_FILE_ERROR";

        /// <summary>
        /// Something is wrong with the pricing record attached to your workspace, please contact support.
        /// </summary>
        public const string IncompletePricing = "INCOMPLETE_PRICING";

        /// <summary>
        /// The Auth Key you used for the operation does not have the required scope.
        /// </summary>
        public const string InsufficientAuthScope = "INSUFFICIENT_AUTH_SCOPE";

        /// <summary>
        /// One of our commands reported an error.
        /// </summary>
        public const string InternalCommandError = "INTERNAL_COMMAND_ERROR";

        /// <summary>
        /// One of our commands timed out.
        /// </summary>
        public const string InternalCommandTimeout = "INTERNAL_COMMAND_TIMEOUT";

        /// <summary>
        /// This is an invalid Assembly status.
        /// </summary>
        public const string InvalidAssemblyStatus = "INVALID_ASSEMBLY_STATUS";

        /// <summary>
        /// Invalid auth expires parameter provided - we could not parse it.
        /// </summary>
        public const string InvalidAuthExpiresParameter = "INVALID_AUTH_EXPIRES_PARAMETER";

        /// <summary>
        /// Invalid Auth Key parameter provided - the value is not a string.
        /// </summary>
        public const string InvalidAuthKeyParameter = "INVALID_AUTH_KEY_PARAMETER";

        /// <summary>
        /// Invalid auth referer parameter provided, could not parse it.
        /// </summary>
        public const string InvalidAuthMaxSizeParameter = "INVALID_AUTH_MAX_SIZE_PARAMETER";

        /// <summary>
        /// Invalid auth referer parameter given, could not parse it.
        /// </summary>
        public const string InvalidAuthRefererParameter = "INVALID_AUTH_REFERER_PARAMETER";

        /// <summary>
        /// We could not parse the meta data for the file #file#.
        /// </summary>
        public const string InvalidFileMetaData = "INVALID_FILE_META_DATA";

        /// <summary>
        /// The form contained bad data, which cannot be parsed.
        /// </summary>
        public const string InvalidFormData = "INVALID_FORM_DATA";

        /// <summary>
        /// The files could not be processed, the provided file format is not supported by this Robot.
        /// </summary>
        public const string InvalidInputError = "INVALID_INPUT_ERROR";

        /// <summary>
        /// Bad params field provided, it contains invalid json.
        /// </summary>
        public const string InvalidParamsField = "INVALID_PARAMS_FIELD";

        /// <summary>
        /// The given signature does not match ours. Maybe your Auth Key demands to use sha384 instead of sha1?
        /// </summary>
        public const string InvalidSignature = "INVALID_SIGNATURE";

        /// <summary>
        /// You must not name a step ":original" that is not using the /upload/handle Robot. This will lead to bad job spawning like duped jobs or infinite Assemblies.
        /// </summary>
        public const string InvalidStepName = "INVALID_STEP_NAME";

        /// <summary>
        /// Bad Template field provided, it contains invalid json.
        /// </summary>
        public const string InvalidTemplateField = "INVALID_TEMPLATE_FIELD";

        /// <summary>
        /// When using the /upload/handle robot, its step name must be ":original".
        /// </summary>
        public const string InvalidUploadHandleStepName = "INVALID_UPLOAD_HANDLE_STEP_NAME";

        /// <summary>
        /// The uploaded file exceeded the file size limit.
        /// </summary>
        public const string MaxSizeExceeded = "MAX_SIZE_EXCEEDED";

        /// <summary>
        /// No auth expires parameter was provided.
        /// </summary>
        public const string NoAuthExpiresParameter = "NO_AUTH_EXPIRES_PARAMETER";

        /// <summary>
        /// No Auth Key parameter provided.
        /// </summary>
        public const string NoAuthKeyParameter = "NO_AUTH_KEY_PARAMETER";

        /// <summary>
        /// No auth parameter provided.
        /// </summary>
        public const string NoAuthParameter = "NO_AUTH_PARAMETER";

        /// <summary>
        /// Your workspace has no country record attached to it, please contact support or update your workspace information.
        /// </summary>
        public const string NoCountry = "NO_COUNTRY";

        /// <summary>
        /// Bad auth parameter provided, it is not an object.
        /// </summary>
        public const string NoObjectAuthParameter = "NO_OBJECT_AUTH_PARAMETER";

        /// <summary>
        /// Bad params field provided, it is not an object.
        /// </summary>
        public const string NoObjectParamsField = "NO_OBJECT_PARAMS_FIELD";

        /// <summary>
        /// No params field provided.
        /// </summary>
        public const string NoParamsField = "NO_PARAMS_FIELD";

        /// <summary>
        /// Your workspace has no pricing record attached to it, please contact support.
        /// </summary>
        public const string NoPricing = "NO_PRICING";

        /// <summary>
        /// Invalid or no result Step defined, which is mandatory for URL Transform Assemblies.
        /// </summary>
        public const string NoResultStepFound = "NO_RESULT_STEP_FOUND";

        /// <summary>
        /// No rpc result from image-resizer
        /// </summary>
        public const string NoRpcResultFromImageResizer = "NO_RPC_RESULT_FROM_IMAGE_RESIZER";

        /// <summary>
        /// No signature field was provided.
        /// </summary>
        public const string NoSignatureField = "NO_SIGNATURE_FIELD";

        /// <summary>
        /// This workspace demands that a Template ID is provided. None was provided, though.
        /// </summary>
        public const string NoTemplateId = "NO_TEMPLATE_ID";

        /// <summary>
        /// You have exceeded the usage limit of your Transloadit plan. Please upgrade your plan to make this error message go away, or get in touch with support.
        /// </summary>
        public const string PlanLimitExceeded = "PLAN_LIMIT_EXCEEDED";

        /// <summary>
        /// One of your files is possibly malicious and cannot be processed.
        /// </summary>
        public const string PossiblyMaliciousFileFound = "POSSIBLY_MALICIOUS_FILE_FOUND";

        /// <summary>
        /// Your priority job slots were successfully found.
        /// </summary>
        public const string PriorityJobSlotsFound = "PRIORITY_JOB_SLOTS_FOUND";

        /// <summary>
        /// Your priority job slots could not be found.
        /// </summary>
        public const string PriorityJobSlotsNotFound = "PRIORITY_JOB_SLOTS_NOT_FOUND";

        /// <summary>
        /// There was an error fetching the queue stats
        /// </summary>
        public const string QueuesListError = "QUEUES_LIST_ERROR";

        /// <summary>
        /// Fetching or resetting the queue actors failed
        /// </summary>
        public const string QueueActorsError = "QUEUE_ACTORS_ERROR";

        /// <summary>
        /// Request limit reached
        /// </summary>
        public const string RateLimitReached = "RATE_LIMIT_REACHED";

        /// <summary>
        /// This request comes from a location that is not allowed.
        /// </summary>
        public const string RefererMismatch = "REFERER_MISMATCH";

        /// <summary>
        /// The original request was closed prematurely.
        /// </summary>
        public const string RequestPrematureClosed = "REQUEST_PREMATURE_CLOSED";

        /// <summary>
        /// Authorization required
        /// </summary>
        public const string Server401 = "SERVER_401";

        /// <summary>
        /// Forbidden
        /// </summary>
        public const string Server403 = "SERVER_403";

        /// <summary>
        /// Unknown method / url
        /// </summary>
        public const string Server404 = "SERVER_404";

        /// <summary>
        /// Unexpected error
        /// </summary>
        public const string Server500 = "SERVER_500";

        /// <summary>
        /// The request was denied for security reasons. If you think this is in error, please get in touch with support.
        /// </summary>
        public const string SignatureReuseDetected = "SIGNATURE_REUSE_DETECTED";

        /// <summary>
        /// Database failed to sync
        /// </summary>
        public const string SyncError = "SYNC_ERROR";

        /// <summary>
        /// Your Template was successfully created.
        /// </summary>
        public const string TemplateCreated = "TEMPLATE_CREATED";

        /// <summary>
        /// Your Template Credentials were successfully created.
        /// </summary>
        public const string TemplateCredentialsCreated = "TEMPLATE_CREDENTIALS_CREATED";

        /// <summary>
        /// Your Template Credentials were successfully deleted.
        /// </summary>
        public const string TemplateCredentialsDeleted = "TEMPLATE_CREDENTIALS_DELETED";

        /// <summary>
        /// Your Template Credentials were successfully found.
        /// </summary>
        public const string TemplateCredentialsFound = "TEMPLATE_CREDENTIALS_FOUND";

        /// <summary>
        /// Your Template Credentials could not be injected.
        /// </summary>
        public const string TemplateCredentialsInjectionError = "TEMPLATE_CREDENTIALS_INJECTION_ERROR";

        /// <summary>
        /// Your Template Credentials could not be created.
        /// </summary>
        public const string TemplateCredentialsNotCreated = "TEMPLATE_CREDENTIALS_NOT_CREATED";

        /// <summary>
        /// Your Template Credentials could not be deleted.
        /// </summary>
        public const string TemplateCredentialsNotDeleted = "TEMPLATE_CREDENTIALS_NOT_DELETED";

        /// <summary>
        /// Your Template Credentials could not be found.
        /// </summary>
        public const string TemplateCredentialsNotFound = "TEMPLATE_CREDENTIALS_NOT_FOUND";

        /// <summary>
        /// Your Template Credentials could not be read.
        /// </summary>
        public const string TemplateCredentialsNotRead = "TEMPLATE_CREDENTIALS_NOT_READ";

        /// <summary>
        /// Your Template Credentials could not be updated.
        /// </summary>
        public const string TemplateCredentialsNotUpdated = "TEMPLATE_CREDENTIALS_NOT_UPDATED";

        /// <summary>
        /// Your Template Credentials were successfully read.
        /// </summary>
        public const string TemplateCredentialsRead = "TEMPLATE_CREDENTIALS_READ";

        /// <summary>
        /// The Template Credentials types were successfully found.
        /// </summary>
        public const string TemplateCredentialsTypesFound = "TEMPLATE_CREDENTIALS_TYPES_FOUND";

        /// <summary>
        /// The Template Credentials types could not be found.
        /// </summary>
        public const string TemplateCredentialsTypesNotFound = "TEMPLATE_CREDENTIALS_TYPES_NOT_FOUND";

        /// <summary>
        /// Your Template Credentials were successfully updated.
        /// </summary>
        public const string TemplateCredentialsUpdated = "TEMPLATE_CREDENTIALS_UPDATED";

        /// <summary>
        /// The Template for this request could not be fetched due to a db error.
        /// </summary>
        public const string TemplateDbError = "TEMPLATE_DB_ERROR";

        /// <summary>
        /// Your Template was successfully deleted.
        /// </summary>
        public const string TemplateDeleted = "TEMPLATE_DELETED";

        /// <summary>
        /// This Template had the allow_steps_override option set to false, so clients are not allowed to temper with its steps.
        /// </summary>
        public const string TemplateDeniesStepsOverride = "TEMPLATE_DENIES_STEPS_OVERRIDE";

        /// <summary>
        /// Your Template was successfully found.
        /// </summary>
        public const string TemplateFound = "TEMPLATE_FOUND";

        /// <summary>
        /// Your Template contained invalid JSON.
        /// </summary>
        public const string TemplateInvalidJson = "TEMPLATE_INVALID_JSON";

        /// <summary>
        /// Bad parameters
        /// </summary>
        public const string TemplateListError = "TEMPLATE_LIST_ERROR";

        /// <summary>
        /// There was no Template found for the given template_id and workspace.
        /// </summary>
        public const string TemplateNotFound = "TEMPLATE_NOT_FOUND";

        /// <summary>
        /// Your Template was successfully updated.
        /// </summary>
        public const string TemplateUpdated = "TEMPLATE_UPDATED";

        /// <summary>
        /// Your Template didn't pass validation.
        /// </summary>
        public const string TemplateValidationError = "TEMPLATE_VALIDATION_ERROR";

        /// <summary>
        /// Transloadit was unable to download a file from our temporary location.
        /// </summary>
        public const string TmpFileDownloadError = "TMP_FILE_DOWNLOAD_ERROR";

        /// <summary>
        /// An invalid file or setting caused a command to fail.
        /// </summary>
        public const string UserCommandError = "USER_COMMAND_ERROR";

        /// <summary>
        /// You need to first verify your email address before you can do this.
        /// </summary>
        public const string VerifiedEmailRequired = "VERIFIED_EMAIL_REQUIRED";

        /// <summary>
        /// Transloadit was unable to process this Assembly.
        /// </summary>
        public const string WorkerJobError = "WORKER_JOB_ERROR";
    }
}
