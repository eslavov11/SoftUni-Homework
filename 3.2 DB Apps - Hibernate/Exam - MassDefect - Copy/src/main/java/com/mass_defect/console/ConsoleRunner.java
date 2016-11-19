package com.mass_defect.console;

import com.mass_defect.data_parsers.JSONParserImpl;
import com.mass_defect.data_parsers.XMLParserImpl;
import com.mass_defect.domain.dto.export_json_dto.PersonExportDto;
import com.mass_defect.domain.dto.export_json_dto.PlanetExportDto;
import com.mass_defect.domain.dto.json_dto.*;
import com.mass_defect.domain.dto.xml_dto.AnomaliesImportDto;
import com.mass_defect.domain.dto.xml_dto.AnomalyWithVictimImportDto;
import com.mass_defect.domain.dto.xml_dto.VictimImportDto;
import com.mass_defect.domain.models.*;
import com.mass_defect.service.*;
import com.mass_defect.utility.Constants;
import com.mass_defect.utility.OutputMessages;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;
import org.springframework.transaction.annotation.Transactional;
import org.xml.sax.SAXException;

import javax.xml.bind.JAXBException;
import java.util.ArrayList;
import java.util.List;

@Component
@Transactional
public class ConsoleRunner implements CommandLineRunner {
    @Autowired
    private AnomalyService anomalyService;

    @Autowired
    private PersonService personService;

    @Autowired
    PlanetService planetService;

    @Autowired
    SolarSystemService solarSystemService;

    @Autowired
    StarService starService;

    @Autowired
    JSONParserImpl jsonParser;

    @Autowired
    XMLParserImpl xmlParser;

    @Override
    public void run(String... strings) throws Exception {
        //JSON import
        this.seedSolarSystems();
        this.seedStars();
        this.seedPlanets();
        this.seedPersons();
        this.seedAnomalies();
        this.seedAnomalyVictims();

        //XML import
        this.seedNewAnomalies();

        //JSON Export
        this.exportOriginPlanetsWithNoAnomalies();
        //this.exportPersonsNotVictims();
    }

    private void seedSolarSystems() {
        SolarSystemImportDto[] solarSystemsDto = this.jsonParser.readFromJSON(SolarSystemImportDto[].class,
                                                     Constants.DATASETS_PATH + "solar-systems.json");
        SolarSystem solarSystem;

        for (SolarSystemImportDto solarSystemImportDto : solarSystemsDto) {
            if (solarSystemImportDto.getName() == null) {
                System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                continue;
            }

            solarSystem = new SolarSystem();
            solarSystem.setName(solarSystemImportDto.getName());

            this.solarSystemService.save(solarSystem);
            System.out.println(String.format(
                    OutputMessages.IMPORT_DATA_SUCCESS_FORMAT, solarSystem.getClass().getSimpleName(), solarSystem.getName()));

        }
    }

    private void seedStars() {
        StarImportDto[] starImportDtos = this.jsonParser.readFromJSON(StarImportDto[].class,
                Constants.DATASETS_PATH + "stars.json");
        Star star;
        SolarSystem solarSystem;

        for (StarImportDto starImportDto : starImportDtos) {
            if (starImportDto.getName() == null || starImportDto.getSolarSystem() == null) {
                System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                continue;
            }

            solarSystem = this.solarSystemService.findSolarSystemByName(starImportDto.getSolarSystem());

            if (solarSystem == null) {
                System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                continue;
            }

            star = new Star();
            star.setName(starImportDto.getName());
            star.setSolarSystem(solarSystem);

            this.starService.save(star);
            System.out.println(String.format(
                    OutputMessages.IMPORT_DATA_SUCCESS_FORMAT, star.getClass().getSimpleName(), star.getName()));
        }
    }

    private void seedPlanets() {
        PlanetImportDto[] planetImportDtos = this.jsonParser.readFromJSON(PlanetImportDto[].class,
                Constants.DATASETS_PATH + "planets.json");
        Planet planet;
        Star sun;
        SolarSystem solarSystem;

        for (PlanetImportDto planetImportDto : planetImportDtos) {
            if (planetImportDto.getName() == null || planetImportDto.getSun() == null || planetImportDto.getSolarSystem() == null) {
                System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                continue;
            }

            sun = this.starService.findStarByName(planetImportDto.getSun());
            solarSystem = this.solarSystemService.findSolarSystemByName(planetImportDto.getSolarSystem());

            if (sun == null || solarSystem == null) {
                System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                continue;
            }

            planet = new Planet();
            planet.setName(planetImportDto.getName());
            planet.setSun(sun);
            planet.setSolarSystem(solarSystem);

            this.planetService.save(planet);
            System.out.println(String.format(
                    OutputMessages.IMPORT_DATA_SUCCESS_FORMAT, planet.getClass().getSimpleName(), planet.getName()));
        }
    }

    private void seedPersons() {
        PersonImportDto[] planetImportDtos = this.jsonParser.readFromJSON(PersonImportDto[].class,
                Constants.DATASETS_PATH + "persons.json");
        Person person;
        Planet homePlanet;

        for (PersonImportDto personImportDto : planetImportDtos) {
            if (personImportDto.getName() == null || personImportDto.getHomePlanet() == null) {
                System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                continue;
            }

            homePlanet = this.planetService.findPlanetByName(personImportDto.getHomePlanet());

            if (homePlanet == null) {
                System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                continue;
            }

            person = new Person();
            person.setName(personImportDto.getName());
            person.setHomePlanet(homePlanet);

            this.personService.save(person);
            System.out.println(String.format(
                    OutputMessages.IMPORT_DATA_SUCCESS_FORMAT, person.getClass().getSimpleName(), person.getName()));
        }
    }

    private void seedAnomalies() {
        AnomalyImportDto[] anomalyImportDtos = this.jsonParser.readFromJSON(AnomalyImportDto[].class,
                Constants.DATASETS_PATH + "anomalies.json");
        Anomaly anomaly;
        Planet originPlanet;
        Planet teleportPlanet;

        for (AnomalyImportDto anomalyImportDto : anomalyImportDtos) {
            if (anomalyImportDto.getOriginPlanet() == null || anomalyImportDto.getTeleportPlanet() == null) {
                System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                continue;
            }

            originPlanet = this.planetService.findPlanetByName(anomalyImportDto.getOriginPlanet());
            teleportPlanet = this.planetService.findPlanetByName(anomalyImportDto.getTeleportPlanet());

            if (originPlanet == null || teleportPlanet == null) {
                System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                continue;
            }

            anomaly = new Anomaly();
            anomaly.setOriginPlanet(originPlanet);
            anomaly.setTeleportPlanet(teleportPlanet);

            this.anomalyService.save(anomaly);
            System.out.println(String.format(
                    OutputMessages.IMPORT_ANOMALY_SUCCESS));
        }
    }

    private void seedAnomalyVictims() {
        AnomalyVictimsImportDao[] anomalyVictimsImportDaos = this.jsonParser.readFromJSON(AnomalyVictimsImportDao[].class,
                Constants.DATASETS_PATH + "anomaly-victims.json");
        Anomaly anomaly;
        Person victim;

        for (AnomalyVictimsImportDao anomalyVictimsImportDao : anomalyVictimsImportDaos) {
            if (anomalyVictimsImportDao.getId() == null || anomalyVictimsImportDao.getPerson() == null) {
                continue;
            }

            anomaly = this.anomalyService.findAnomaly(anomalyVictimsImportDao.getId());
            victim = this.personService.findPersonByName(anomalyVictimsImportDao.getPerson());

            if (anomaly == null || victim == null) {
                continue;
            }

            anomaly.getVictims().add(victim);

            this.anomalyService.save(anomaly);
        }
    }

    private void seedNewAnomalies() throws JAXBException, SAXException {
        AnomaliesImportDto anomaliesImportsDtos = this.xmlParser.readFromXml(AnomaliesImportDto.class,
                Constants.DATASETS_PATH + "new-anomalies.xml");
        Anomaly anomaly;
        Planet originPlanet;
        Planet teleportPlanet;
        Person victim;

        for (AnomalyWithVictimImportDto anomalyWithVictimImportDto : anomaliesImportsDtos.getAnomalies()) {
            if (anomalyWithVictimImportDto.getOriginPlanet() == null ||
                    anomalyWithVictimImportDto.getTeleportPlanet() == null) {
                System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                continue;
            }

            for (VictimImportDto victimImportDto : anomalyWithVictimImportDto.getVictims()) {
                if (victimImportDto.getName() == null) {
                    System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                    continue;
                }

                originPlanet = this.planetService.findPlanetByName(anomalyWithVictimImportDto.getOriginPlanet());
                teleportPlanet = this.planetService.findPlanetByName(anomalyWithVictimImportDto.getTeleportPlanet());
                victim = this.personService.findPersonByName(victimImportDto.getName());

                if (originPlanet == null || teleportPlanet == null || victim.getName() == null) {
                    System.out.println(OutputMessages.IMPORT_DATA_INVALID);
                    continue;
                }

                anomaly = new Anomaly();
                anomaly.setOriginPlanet(originPlanet);
                anomaly.setTeleportPlanet(teleportPlanet);
                anomaly.getVictims().add(victim);

                this.anomalyService.save(anomaly);
                System.out.println(OutputMessages.IMPORT_GENERAL_DATA_SUCCESS);
            }
        }
    }

    private void exportOriginPlanetsWithNoAnomalies() {
        Iterable<Planet> planets = this.planetService.findPlanetsWhichAreNotAnomalyOrigins();

        List<PlanetExportDto> planetExportDtos = new ArrayList<>();

        for (Planet planet : planets) {
            PlanetExportDto p = new PlanetExportDto();
            p.setName(planet.getName());
            planetExportDtos.add(p);
        }

        this.jsonParser.writeToJSON(planetExportDtos, Constants.DATASETS_PATH + "planets-with-no-anomalies.json");
    }

    /*private void exportPersonsNotVictims() {
        Iterable<Person> persons = this.personService.findPersonsNotVictims();

        List<PersonExportDto> personExportDtos = new ArrayList<>();

        for (Person person : persons) {
            PersonExportDto p = new PersonExportDto();
            p.setName(person.getName());

            PlanetExportDto planetExport = new PlanetExportDto();
            planetExport.setName(person.getHomePlanet().getName());

            p.setHomePlanet(planetExport);
            personExportDtos.add(p);
        }

        this.jsonParser.writeToJSON(personExportDtos, Constants.DATASETS_PATH + "persons.json");
    }*/
}
