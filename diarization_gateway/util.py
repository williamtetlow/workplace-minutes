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
