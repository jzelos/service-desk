export function reviver(key: any, value: any) {
    const dateFormat = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(\.\d{7})?Z$/;
    if (typeof value === "string" && dateFormat.test(value)) {
        return new Date(value);
    }
    return value;
}

/* const origParser = JSON.parse;

JSON.parse = (text: string) => {
    return origParser(text, reviver);
} */