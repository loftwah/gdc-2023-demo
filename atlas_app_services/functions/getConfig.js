exports = async function({ query, headers, body}, response) {
    
    let filter = {};

    const doc = await context.services.get("mongodb-atlas").db("game").collection("config").findOne(filter);

    return  doc;
    
};
