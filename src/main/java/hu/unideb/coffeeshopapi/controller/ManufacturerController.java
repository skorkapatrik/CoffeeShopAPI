package hu.unideb.coffeeshopapi.controller;

import hu.unideb.coffeeshopapi.domain.Manufacturer;
import hu.unideb.coffeeshopapi.repository.ManufacturerRepository;
import hu.unideb.coffeeshopapi.service.ManufacturerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@CrossOrigin
@RequestMapping("/api/")
public class ManufacturerController {

    @Autowired
    private ManufacturerService manufacturerService;

    @GetMapping("/manufacturer")
    public List<Manufacturer> getAllManufacturer(){
        return manufacturerService.getAllManufacturer();
    }

    @GetMapping("/manufacturer/{id}")
    public Manufacturer getManufacturerById(@PathVariable String id){
        return manufacturerService.getManufacturerById(Long.valueOf(id));
    }

    @PostMapping("/manufacturer")
    public Manufacturer addManufacturer(@RequestBody Manufacturer manufacturer){
        return manufacturerService.saveManufacturer(manufacturer);
    }

}
