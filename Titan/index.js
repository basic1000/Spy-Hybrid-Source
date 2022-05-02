const bodyParser = require('body-parser');
const express = require('express');
const fs = require('fs');
const axios = require('axios');
const log = require('./structs/log');
class backend {

    get directory() {
        return `${__dirname}`;
    }

    constructor() {
        this.config = require(`${this.directory}/config`);
        this.app = express();
    }

    loadProfile(profileId) {
        return JSON.parse(fs.readFileSync(`${this.directory}/acc/templates/profile_${profileId}.json`));
    };

    async updateAthena() {
        while (true) {
            const req = await axios.get(
                'https://fortnite-api.com/v2/cosmetics/br/'
            );
            var athena = this.loadProfile("athena");
            var items = req.data.data;

            items.forEach(
                cosmetic => {
                    var cosmeticVariants = [];

                    if (cosmetic.variants) {
                        cosmetic.variants.forEach(
                            variant => {
                                var owned = [];
                                variant.options.forEach(option => {owned.push(option.tag)});
                                cosmeticVariants.push({
                                        'channel': variant.channel,
                                        'active': owned[0],
                                        'owned': owned
                                    })
                            })
                    };

                    athena.items[`${cosmetic.type.backendValue}:${cosmetic.id}`] = {
                        'templateId': `${cosmetic.type.backendValue}:${cosmetic.id}`,
                        'attributes': {
                            'max_level_bonus': 69420,
                            'level': 1,
                            'item_seen': true,
                            'rnd_sel_cnt': 0,
                            'xp': 69420,
                            'variants': cosmeticVariants,
                            'favorite': false 
                        },
                        'quantity': 1
                    };
                }
            )
            fs.writeFileSync(`${this.directory}/acc/templates/profile_athena.json`, JSON.stringify(athena, null, 2));
            log.log("Loaded Cosmetics!")
            await new Promise(r => setTimeout(r, 1800000));
        }
    }

    router() {
        this.app.use(
            (req, res, next) => {
              
                log.request(`${req.url}`);
                next();
            }
        )

        fs.readdirSync(`${this.directory}/handling`).forEach(
            route => {
                this.app.use(require(`${this.directory}/handling/${route.split('.')[0]}`))
            }
        )
    }

    init() {
        this.app.use(bodyParser.json());
        this.app.use(bodyParser.urlencoded({
            extended: true
        }));
        
        this.updateAthena();
        this.router();
        this.app.listen(
            process.env.PORT || this.config.port, () => {
                log.log(`Titan is running on port ${process.env.PORT || this.config.port}.`);
            }
        )
    }
}

backendClass = new backend();
backendClass.init();