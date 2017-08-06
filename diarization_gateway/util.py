import json


def print_json(x):
    print(json.dumps(x, indent=2))


def save_json(json_data, filepath):
    with open(filepath, 'w') as fp:
        json.dump(json_data, fp)


def open_json(filepath):
    with open(filepath, 'r') as f:
        data = json.load(f)
    return data


def detect_content_type(filepath):
    valid_extensions = ['mp3', 'wav', 'flac', 'ogg', 'webm', 'l16', 'mulaw']
    extension = filepath.split('.')[-1]
    if extension in valid_extensions:
        return 'audio/{}'.format(extension)
    else:
        raise ValueError("File format not recognized. "
                         "Please upload files of valid extension: {}".format(valid_extensions))
