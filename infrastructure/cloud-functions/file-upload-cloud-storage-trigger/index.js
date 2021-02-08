const pubsub = require('@google-cloud/pubsub')();

/**
 * Background Cloud Function to be triggered by Cloud Storage when a file is uploaded.
 * To deploy: gcloud beta functions deploy fileUploadCloudStorageTrigger --stage-bucket workplace-cloud-functions-staging --trigger-bucket workplace-3d1d6.appspot.com
 *
 * @param {object} event The Cloud Functions event.
 * @param {function} callback The callback function.
 */
exports.fileUploadCloudStorageTrigger = function (event, callback) {
  const file = event.data;

  if (file.resourceState === 'not_exists') {
    console.log(`File ${file.name} deleted.`);
  } else if (file.metageneration === '1') {
    // metageneration attribute is updated on metadata changes.
    // on create value is 1
    console.log(`File ${file.name} uploaded.`);
  } else {
    console.log(`File ${file.name} metadata updated.`);
  }

  const topic = pubsub.topic('application-updates');
    
  topic.publish({ eventType: "NEW_FILE_UPLOADED", uploadedFileId: file.name }).then(function(data) {
    var messageIds = data[0];
    console.log(data);
  });

  callback();
};