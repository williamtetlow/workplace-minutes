/**
 * Background Cloud Function to be triggered by Pub/Sub.
 * To Deploy: gcloud beta functions deploy applicationUpdatesPubsubTrigger --stage-bucket workplace-cloud-functions-staging --trigger-topic application-updates
 * @param {object} event The Cloud Functions event.
 * @param {function} callback The callback function.
 */
exports.applicationUpdatesPubsubTrigger = function (event, callback) {
  const pubsubMessage = event.data;
  const messageContent = Buffer.from(pubsubMessage.data, 'base64').toString()
  console.log('Received Message', messageContent);

  callback();
};

