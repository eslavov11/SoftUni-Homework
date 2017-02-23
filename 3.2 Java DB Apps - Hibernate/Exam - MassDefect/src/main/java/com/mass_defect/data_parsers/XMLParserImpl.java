package com.mass_defect.data_parsers;

import org.springframework.stereotype.Component;
import org.xml.sax.SAXException;

import javax.xml.bind.*;
import java.io.File;

/**
 * Created by Edi on 19-Nov-16.
 */
@Component
public class XMLParserImpl {
    public <T> T readFromXml (Class<T> classes, String fileName) throws JAXBException, SAXException {
        JAXBContext jaxbContext = JAXBContext.newInstance(classes);
        Unmarshaller unmarshaller = jaxbContext.createUnmarshaller();
        File file = new File(fileName);
        T objects = (T) unmarshaller.unmarshal(file);

        return objects;
    }

    public <T> void writeToXml(T object, String fileName) throws JAXBException {
        JAXBContext jaxbContext = JAXBContext.newInstance(object.getClass());
        Marshaller marshaller = jaxbContext.createMarshaller();
        marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, Boolean.TRUE);
        File file = new File(fileName);
        marshaller.marshal(object, file);
    }
}
