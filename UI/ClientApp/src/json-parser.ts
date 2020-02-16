export function reviver(key: string, value: any) {
    const dateFormat = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(\.\d{1,7})?Z$/;
    if (typeof value === "string" && dateFormat.test(value)) {
        return new Date(value);
    }
    return value;
}

const origParser = JSON.parse;

JSON.parse = (text: string) => {
    try {
        var res = origParser(text, reviver);
        return res;
    } catch (e) {        
        throw new Error("JSON content could not be parsed");
    }
}  