package core;

import java.lang.reflect.InvocationTargetException;

/**
 * Created by Edi on 07-Aug-16.
 */
public interface CommandExecutor {
    String execute(Command command) throws ClassNotFoundException, NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException;
}
